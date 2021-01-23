    class exDataGridView : DataGridView
    {
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int KEYUP = 38;
        private const int KEYDOWN = 40;
    
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    if (m.WParam == (IntPtr)KEYDOWN)
                    {
                        // Do key down stuff...
                        return;
                    }
                    else if (m.WParam == (IntPtr)KEYUP)
                    {
                        // Do key up stuff...
                        return;
                    }
                    break;
            }
                
            base.WndProc(ref m);
        }
    }
