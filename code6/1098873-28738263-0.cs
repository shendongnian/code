    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    namespace GraphicsForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Invalidate();
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var g = e.Graphics;
                var w = ClientRectangle.Width;
                var h = ClientRectangle.Height;
                var midY = h/2;
                var midX = w/2;
                var linePen = new Pen(Brushes.Red, 1)
                {
                    StartCap = LineCap.DiamondAnchor,
                    EndCap = LineCap.DiamondAnchor
                };
                //horizontal line
                g.DrawLine(linePen, 0, midY, w, midY);
                var font = Font;
                var measureStringX = g.MeasureString("x", font);
                g.DrawString("x", font, Brushes.Black, w - measureStringX.Width - 2, midY + 2);
                //vertical line
                g.DrawLine(linePen, midX, 0, midX, h);
                g.DrawString("y", font, Brushes.Black, midX + 2, 2);
                //horizontals&vertical marks
                const float marksCount = 12f;
                var wx = w / marksCount;
                var hx = h / marksCount;
                var markPen = new Pen(Brushes.Red, 1);
                for (int i = 1; i < marksCount; i++)
                {
                    g.DrawLine(markPen, i * wx, midY, i * wx, midY + 5);
                    g.DrawLine(markPen, midX, hx * i, midX + 5, hx * i);
                }
            }
        }
    }
