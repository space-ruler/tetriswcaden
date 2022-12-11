﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris
{

    public partial class Form1 : Form
    {
        public Label[,] grid = new Label[8, 12];
        public Label[,] sGrid = new Label[4, 4];
        List<Label> Piece = new List<Label>();
        List<Label> PieceList = new List<Label>();
        List<Point> Pos = new List<Point>();
        List<int> yPos = new List<int>();
        int type;
        
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            SpawnGrid();
            PopulatePositionLists();
            type = 0;
            //SpawnBlock1();
            //Rotate();
            EasierRotation();
           // SpawnBlock2();
        }
        private void PopulatePositionLists()
        {
            //Should add an ability to add an offset by like a plus i 
            Pos.Add(sGrid[0, 0].Location);
            Pos.Add(sGrid[0, 1].Location);
            Pos.Add(sGrid[0, 2].Location);
            Pos.Add(sGrid[0, 3].Location);

            Pos.Add(sGrid[1, 0].Location);
            Pos.Add(sGrid[1, 1].Location);
            Pos.Add(sGrid[1, 2].Location);
            Pos.Add(sGrid[1, 3].Location);

            Pos.Add(sGrid[2, 0].Location);
            Pos.Add(sGrid[2, 1].Location);
            Pos.Add(sGrid[2, 2].Location);
            Pos.Add(sGrid[2, 3].Location);

            Pos.Add(sGrid[3, 0].Location);
            Pos.Add(sGrid[3, 1].Location);
            Pos.Add(sGrid[3, 2].Location);
            Pos.Add(sGrid[3, 3].Location);
            tmrMove.Enabled = true;
            MessageBox.Show(Pos.Count().ToString());
        }

        private void SpawnBlock2()
        {
            //Piece piece1 = new Piece(1, 1, 3);

            //So we can create a list of lists and seperate each piece by block (which we should do so they can be cleared later)
            //or i can high light blocks, i have just been having trouble keeping track of where multiple pieces are and rotating(tho this is a possible solution)
            //or a single piece and maybe make a conglomeration at the bottom idk man.

        // spawn 3x3 to hold piece and put that grid in a list 
        //could use tags to know which blocks have a piece instead of rnning a seperate item
             

            // Do this 
            //Try adding tags to the current positions for easier rotation and then shift the whole grid down
            if (type == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Label label = new Label();
                    label.BackColor = Color.Blue;
                    label.AutoSize = false;
                    label.Size = grid[0, 0].Size;
                    label.Location = new Point();
                    Controls.Add(label);
                    Piece.Add(label);
                    label.BringToFront();
                   
                }
                MessageBox.Show(Piece.Count().ToString());
                Piece[0].Location = Pos[5];
                Piece[1].Location = Pos[6];
                Piece[2].Location = Pos[9];
                Piece[3].Location = Pos[10];

            }
        }

        private void EasierRotation()
        {
            
        }
        private void SpawnGrid()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(5 + (45 * r), 5 + (45 * c));
                    label.BackColor = Color.Black;
                    label.Size = new Size(40, 40);
                    label.Text = r.ToString() +"," + c.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    Controls.Add(label);
                    grid[r, c] = label;
                }
            }

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c< 4; c++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(5 + (45 * r), 5 + (45 * c));
                    label.BackColor = Color.Blue;
                    label.Size = new Size(40, 40);
                    label.Text = r.ToString() + "," + c.ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    Controls.Add(label);
                    sGrid[r, c] = label;
                }
            }
        }
        private void Rotate()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                
            }
        }
        int x = 0;
        int y = 0;

        private void SpawnBlock()
        {
            for (int c=2; c <=5; c++)
            {
                for (int r = 0; r < 4; r ++)
                {
                    grid[c, r].BackColor = Color.SaddleBrown;
                }
            }

            if(type ==0)
            {
                grid[3, 1].BackColor = Color.Red;
                grid[3,2].BackColor = Color.Red;

                grid[4, 1].BackColor = Color.Red;
                grid[4,2].BackColor = Color.Red;


            }
            else if(type == 1)
            {
                grid[2, 1].BackColor = Color.Red;
                grid[3, 1].BackColor = Color.Red;
                grid[4, 1].BackColor = Color.Red;
                grid[4, 2].BackColor = Color.Red;
            }
            try
            {

            }
            catch
            {

            }
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int r = 0; r < grid.GetLength(0); r++)
                {
                    for (int c = 0; c < grid.GetLength(1); c++)
                    {
                        if (grid[c,r].BackColor == Color.Red)
                        {
                            grid[c, r +1].BackColor = grid[c,r ].BackColor;
                            //grid[c,r].BackColor = Color.Black;
                        }
                    }
                }
            }
            catch
            {

            }

            for (int i = 0; i < Pos.Count; i++)
            {
                Pos[i] = new Point(Pos[i].X, Pos[i].Y + 1);
                for (i = 0; i < Pos.Count; i++)
                {

                    Pos[i].Top++;
                }
            }


        }
    }
}
