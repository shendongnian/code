    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Paddle_Test
    {
        public partial class Form1 : Form
        {
            Rectangle rec;
            Rectangle circle;
            int wLoc=0;
                int hLoc=0;
                int eWL;
                int eHL;
                int dx = 2;
                int dy = 2;
    
            public Form1()
            {
                InitializeComponent();
                wLoc=(this.Width) - 100;
                hLoc=(this.Height) - 100;
                eWL = 10;
                eHL = 10;
                rec = new Rectangle(wLoc,hLoc , 100, 10);
                circle = new Rectangle(eWL, eHL, 40, 40);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Refresh();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                
                g.FillRectangle(new SolidBrush(Color.Blue), rec);
                g.FillEllipse(new SolidBrush(Color.Red), circle);
                
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode==Keys.Left)
                {
                    rec.X -= 30;
                    this.Refresh();
                }
    
                if (e.KeyCode==Keys.Right)
                {
                    rec.X += 30;
                    this.Refresh();
                }
            }
    
            int count=0;
            private void timer_Tick(object sender, EventArgs e)
            {
    
                circle.X += dx;
                circle.Y += dy;
                count += 1;
    
                if (circle.X >= (this.Width) - 100)
                {
                    dx = dx * (-1);
                }
                else if (circle.Y >= (this.Height))
                {
                    //dy = dy * (-1);
                    timer.Enabled = false;
                    MessageBox.Show("Game Over!");
                }
                else if (circle.X <= 0)
                {
                    dx = dx * (-1);
                }
                else if (circle.Y <= 0)
                {
                    dy = dy * (-1);
                }
    
                else if (rec.IntersectsWith(circle))//detects collision!
                {
                    //dx = dx * (-1);
                    dy = dy * (-1);
                    
                    Console.WriteLine("hello");
                }
                
                this.Refresh();
            }
        }
    }
