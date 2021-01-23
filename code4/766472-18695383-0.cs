    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
                    
            Rectangle tbSize = new Rectangle(10, 10, 50, 20); // get your rectangle size from your text box
            Rectangle invalSize = new Rectangle(10, 10, 51, 21); // must be slightly bigger due to where the lines are drawn
    
            Timer _timer = new Timer();
            bool painting = true;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this._timer.Interval = 1000;
                this._timer.Enabled = true;
                this._timer.Tick += new EventHandler(_timer_Tick);
                this._timer.Start();
            }
    
    
            protected override void OnPaint(PaintEventArgs e)
            {
                if (painting)
                {
                    DrawRectangle(tbSize); 
                }
    
                base.OnPaint(e);
            }
    
            private void DrawRectangle(Rectangle coords)
            {
                Graphics dc = this.CreateGraphics();
                Pen bluePen = new Pen(Color.Blue, 1);
                dc.DrawRectangle(bluePen, coords);
            }
    
            private void _timer_Tick(object sender, EventArgs e)
            {
                painting = !painting;
                this.Invalidate(invalSize);
            }
                    
        }
    }
