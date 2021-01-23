            public Form1()
            {
                InitializeComponent();
    
                this.Text = string.Empty;
                this.ControlBox = false;
            }
    
            protected override void WndProc(ref Message m)
            {
                const int WM_NCHITTEST = 0x0084;
    
                if (m.Msg == WM_NCHITTEST)
                    return;
                
                base.WndProc(ref m);
            }
