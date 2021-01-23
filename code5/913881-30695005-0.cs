    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace drawing
    {
        public partial class Form2 : Form
        {
            Graphics g;
            bool startPaint = false;
            int? initX = null;
            int? initY = null;
    
            bool drawSquare = false;
            bool drawRectangle = false;
            bool drawCircle = false;
            public Form2()
            {
                InitializeComponent();
    
                bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
    
            }
            Bitmap bmp;
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
              
            }
            void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (startPaint)
                {
                    using ( g = Graphics.FromImage(bmp))
                    {
                      //  g.FillEllipse(Brushes.Black, new Rectangle(e.X, e.Y , 5, 5));
    
                        Pen p = new Pen(btn_PenColor.BackColor, float.Parse(cmb_PenSize.Text));
                        g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                        initX = e.X;
                        initY = e.Y;
                        //g.DrawImage(bmp, new Rectangle(e.X - 4, e.Y - 4, 8, 8));
                    }
                    panel1.Invalidate();
                }
            }
            private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
            {
                startPaint = true;
                 if (drawSquare)
                 {
                     //Use Solid Brush for filling the graphic shapes
                     SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                     //setting the width and height same for creating square.
                     //Getting the width and Heigt value from Textbox(txt_ShapeSize)
                     g.FillRectangle(sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                     //setting startPaint and drawSquare value to false for creating one graphic on one click.
                     startPaint = false;
                     drawSquare = false;
                 }
                 if (drawRectangle)
                 {
                     SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                     //setting the width twice of the height
                     g.FillRectangle(sb, e.X, e.Y, 2 * int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                     startPaint = false;
                     drawRectangle = false;
                 }
                 if (drawCircle)
                 {
                     SolidBrush sb = new SolidBrush(btn_PenColor.BackColor);
                     g.FillEllipse(sb, e.X, e.Y, int.Parse(txt_ShapeSize.Text), int.Parse(txt_ShapeSize.Text));
                     startPaint = false;
                     drawCircle = false;
                 }
            }
             private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
            {
                startPaint = false;
                initX = null;
                initY = null;
            }
            void panel1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawImage(bmp, Point.Empty);
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                bmp.Save("D://filename.jpg", ImageFormat.Png);
            }
    
           
        }
    }
