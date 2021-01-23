    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace Journal
    {
        class CustomRichTextBox : RichTextBox
        {
            private const int WM_HSCROLL      = 0x114;
            private const int WM_VSCROLL      = 0x115;
            private const int WM_MOUSEWHEEL   = 0x20A;
            private const int WM_PAINT        = 0x00F;
            private const int EM_GETSCROLLPOS = 0x4DD;
            public int lineOffset = 0;
    
           [DllImport("user32.dll")]
            public static extern int SendMessage(
                  IntPtr hWnd,
                  int Msg,
                  IntPtr wParam,
                  ref Point lParam 
                  );
    
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
    
                if (m.Msg == WM_PAINT)
                {
                    using (Graphics g = base.CreateGraphics())
                    {
                        Point p = new Point();
    
                        //get the position of the scrollbar to calculate the offset
                        SendMessage(this.Handle, EM_GETSCROLLPOS, IntPtr.Zero, ref p);
    
                        //draw the pink line on the side
                        g.DrawLine(new Pen(Brushes.LightPink, 2), 0, 0, 0, this.Height);
    
                        //determine how tall the text will be per line
                        int h = TextRenderer.MeasureText("Testj", this.Font).Height;
    
                        //calculate where the lines need to start
                        lineOffset = h - (p.Y % h);
    
                        //draw lines until there is no more box
                        for (int x = lineOffset; x < Height; x += h)
                        {
                            g.DrawLine(new Pen(Brushes.LightSkyBlue, 2), 0, x, Width, x);
                        }
    
                        //force the panel under us to draw itself.
                        Parent.Invalidate();
                    }
                }
    
            }
    
            public CustomRichTextBox()
            {
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }
    
        }
    }
    
