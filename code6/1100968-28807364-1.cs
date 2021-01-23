    class MouseTransparentTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x020A: // WM_MOUSEWHEEL
                case 0x020E: // WM_MOUSEHWHEEL
                    if (this.ScrollBars == ScrollBars.None && this.Parent != null)
                        m.HWnd = this.Parent.Handle; // forward this to your parent
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
