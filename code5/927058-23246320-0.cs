        System.Windows.Forms.NotifyIcon m_NotifyIcon;
        public StartWindow()
        {
            InitializeComponent();
            m_NotifyIcon = new System.Windows.Forms.NotifyIcon();
            m_NotifyIcon.Icon = new System.Drawing.Icon(IconPath);
            m_NotifyIcon.Visible = true;
            m_NotifyIcon.BalloonTipTitle = "Tip here";
            m_NotifyIcon.Text = "Text here";
            m_NotifyIcon.DoubleClick += delegate(object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (m_NotifyIcon != null)
                    m_NotifyIcon.Dispose();
            }
            catch { }
            base.OnClosing(e);
        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();
            base.OnStateChanged(e);
        }
