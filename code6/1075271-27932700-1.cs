        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0115) // WM_VSCROLL
            {
                // Get the scroll pos out of m.WParam and update the button positions
            }
            base.WndProc(ref m);
        }
