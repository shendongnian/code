        public static bool MainWindowClosing;
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x112 && (m.WParam.ToInt32() & 0xfff0) == 0xf060) {
                MainWindowClosing = true;
            }
            base.WndProc(ref m);
        }
