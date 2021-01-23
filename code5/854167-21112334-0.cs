        public win1()         
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0,0,1), DispatcherPriority.Normal, delegate
            {
                this.textb.Text = DateTime.Now.ToString("HH:mm:ss tt");
                if (_w2 != null)
                    _w2.passval = textb.Text;
            }, this.Dispatcher);
        }
        private win2 _w2 = null; // Reference to your Win2
        private void but_send_Click(object sender, RoutedEventArgs e)
        {
            _w2 = new win2();
            _w2.passval = textb.Text;
            this.Hide();
            w2.ShowDialog();
        }
