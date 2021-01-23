        public Form1()
        {
            InitializeComponent();
            _prevDate = dateTimePicker1.Value;
        }
        private DateTime _prevDate;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            TimeSpan diff = dt - _prevDate;
            if (diff.Ticks < 0) 
                dateTimePicker1.Value = _prevDate.AddMinutes(-30);
            else 
                dateTimePicker1.Value = _prevDate.AddMinutes(30);
            _prevDate = dateTimePicker1.Value;
        }
