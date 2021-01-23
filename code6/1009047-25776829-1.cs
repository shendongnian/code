        protected override void WndProc(ref Message m)
        {
            int WM_SYSCOMMAND = 0x0112;
            int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && m.WParam == new IntPtr(SC_CLOSE))
            {
                WindowState = FormWindowState.Minimized;
                return;
            }
            base.WndProc(ref m);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
