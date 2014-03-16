using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int[,] show = new int[101, 101];
        int[,] calc = new int[101, 101];
        int sum = 0;
        

        public Form1()
        {
            
            InitializeComponent();
           
                start(); //fill arrays with 0
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
           // this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void start()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    show[x, y] = 0;
                    calc[x, y] = 0;
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void copy()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    show[x, y] = calc[x, y];
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            Refresh();
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }

        #region newgen
        private void newgeneration()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    if ((y == 0) && (x == 0))   // Calculate Top left
                    {
                        if (show[x + 1, y] + show[x + 1, y + 1] + show[x, y + 1] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x == 100))   // Calculate Top right
                    {
                        if (show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 0))   // Calculate Bottom Left
                    {
                        if (show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 100)) // Calculate Bottom Right
                    {
                        if (show[x, y - 1] + show[x - 1, y - 1] + show[x - 1, y] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x > 0) && (x < 100)) //Calculate Top
                    {
                        //int sum = 0;
                        sum = show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1] + show[x + 1, y + 1] + show[x + 1, y];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 0) && (y != 0) && (y != 100)) //Calculate Left
                    {
                        //int sum = 0;
                        sum = show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y] + show[x + 1, y + 1] + show[x, y + 1] + 1;

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 100) && (y != 0) && (y != 100)) //Calculate Right
                    {
                        //int sum = 0;
                        sum = show[x, y - 1] + show[x - 1, y - 1] + show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((y == 100) && (x != 0) && (x != 100)) //Calculate Bottom
                    {
                        //int sum = 0;
                        sum = show[x - 1, y] + show[x - 1, y - 1] + show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x != 0) && (y != 0) && (x != 100) && (y != 100)) //Calculate Center
                    {
                        //int sum = 0;
                        sum = show[x - 1, y - 1] + show[x, y - 1] + show[x + 1, y - 1] + show[x - 1, y] + show[x + 1, y] + show[x - 1, y + 1] + show[x, y + 1] + show[x + 1, y + 1];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            copy();
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }
        #endregion

        /*    private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 0;
            int x = 0;
            int a = 15;
            while (y < 100)
            {
                while (x < 100)
                {
                    if (show[x, y] == 1)
                    {
                        Brush brush = new SolidBrush(Color.Yellow);
                        g.FillRectangle(brush, x * a + a, y * a + a, 10, 10);
                    }
                    else
                    {
                        Brush brush = new SolidBrush(Color.Black);
                        g.FillRectangle(brush, x * a + a, y * a + a, 10, 10);
                    }
                    x++;
                }
                x = 0;
                y++;
            }
            x = 0;
            y = 0;
        }*/
        int starts = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            //start from button
            if (starts == 1)
            {
                starts = 0;
            }
            else
            {
                starts = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if button is clicked, start newgeneration method   
            if (starts == 1)
            {
                newgeneration();
            }
            else { Refresh(); }
        }

      /*  private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int xe = e.X;
            int ye = e.Y;
            int a = 15; 
            show[(xe - a) / a, (ye - a) / a] = 1;
            calc[(xe - a) / a, (ye - a) / a] = 1;
        }*/

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //paint in picturebox
            Graphics g = e.Graphics;
            int y = 0;
            int x = 0;
            int a = 15;
            while (y < 100)
            {
                while (x < 100)
                {
                    if (show[x, y] == 1)
                    {
                        Brush brush = new SolidBrush(Color.Green);
                        g.FillRectangle(brush, x * a + a, y * a + a, 10, 10);
                    }
                    else
                    {
                        Brush brush = new SolidBrush(Color.Red);
                        g.FillRectangle(brush, x * a + a, y * a + a, 10, 10);
                    }
                    x++;
                }
                x = 0;
                y++;
            }
            x = 0;
            y = 0;
        }

        int clicks = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicks = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reset from button
          start();
          starts = 0;    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Thank you come back soon! :)");
            this.Close(); // close from button
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start from menu
            if (starts == 1)
            {
                starts = 0;
            }
            else
            {
                starts = 1;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Thank you come back soon! :)");
            this.Close(); //close from menu
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reset from menu
            start();
            starts = 0;  
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Click on some dots and then start to see the game! Enjoy!");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            clicks = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int xe = e.X;
            int ye = e.Y;
            int a = 15;
            if (xe < 606 && xe > 6 && ye < 606 && ye > 6 && clicks == 1)
            {
                if (e.Button == MouseButtons.Right) // | Right Click > Cell Die |
                {
                    show[(xe - a) / a, (ye - a) / a] = 0;
                    calc[(xe - a) / a, (ye - a) / a] = 0;
                }
                else    // | Left Click > Cell Alive |
                {
                    show[(xe - a) / a, (ye - a) / a] = 1;
                    calc[(xe - a) / a, (ye - a) / a] = 1;
                }
            }
        }

       

        }

       




    }

