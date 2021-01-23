        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch(m.Msg)
            {
                case 0x85: // WM_CPAINT
                case 0xf:  // WM_PAINT
                {
                    g = Graphics.FromHwnd(this.Handle);
                    Rectangle r = GetWndRect(this.Handle);
                    g.DrawRectangle(p, r);
                    Trace.WriteLine("WM_PAINT: "+r.ToString());
                }
                break;
                case 0x05: // WM_SIZE
                {
                    InvalidateRect(this.Handle, IntPtr.Zero, true);
                    Trace.WriteLine("WM_SIZE");
                }
                break;
                default:
                    Trace.WriteLine("0x" + m.Msg.ToString("X"));
                break;
            }
        }
