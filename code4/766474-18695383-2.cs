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
                    
            // Get your rectangle size from your text box
            Rectangle tbSize = new Rectangle(10, 10, 50, 20); 
            // invalSize must be slightly bigger due to where the lines are drawn
            Rectangle invalSize = new Rectangle(10, 10, 51, 21); 
    
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
                base.OnPaint(e);
                if (painting)
                {
                    // e.Graphics uses what Windows has decided needs to be repainted
                    // eg only the small rectangle we are drawing, or our rect and
                    // a control on the other side of the form
                    DrawBorderRect(tbSize, e.Graphics); 
                }
            }
            private void DrawBorderRect(Rectangle coords, Graphics dc)
            {
                Pen bluePen = new Pen(Color.Blue, 1);
                dc.DrawRectangle(bluePen, coords);
            }
    
            private void _timer_Tick(object sender, EventArgs e)
            {
                painting = !painting;
            
                // This will make Windows raise a paint event so we don't have to.
                // Doing it this way allows Windows to combine multiple small paint
                // events to maximise efficiency
                this.Invalidate(invalSize); 
            }
                    
        }
    }
