    public class CustomListView : ListView {
            bool scrollDown;
            int lastScroll;
            public Color GridLinesColor {get;set;}
            public CustomListView(){
               GridLinesColor = Color.Red;
               DoubleBuffered = true;
            }
            protected override void WndProc(ref Message m)
            {                
                if (m.Msg == 0x20a){//WM_MOUSEWHEEL = 0x20a
                    scrollDown = (m.WParam.ToInt64() >> 16) < 0;
                }
                if (m.Msg == 0x115){//WM_VSCROLL = 0x115
                    int n = (m.WParam.ToInt32() >> 16);
                    scrollDown = n > lastScroll;
                    lastScroll = n;
                }                
                base.WndProc(ref m);
                if (m.Msg == 0xf && GridLines && Items.Count > 0&&View=View.Details)//WM_PAINT = 0xf
                {                    
                    using (Graphics g = CreateGraphics())
                    {
                        int w = 0;
                        for (int i = 0; i < Columns.Count; i++)
                        {
                            w += Columns[i].Width;
                            g.DrawLine(new Pen(GridLinesColor), new Point(w, 0), new Point(w, ListView.ClientSize.Height));
                        }
                        int a = Items[0].Bounds.Bottom - 1;
                        int b = Height - Items[0].Bounds.Y;
                        int c = Items[0].Bounds.Height;
                        for (int i = scrollDown ? a + (b/c) * c : a ; scrollDown ? i >= a : i < b ; i += scrollDown ? -c : c)
                        {
                            g.DrawLine(new Pen(GridLinesColor), new Point(0, i), new Point(ClientSize.Width, i));
                        }                                                
                    }                 
                }
                
            }
    }
