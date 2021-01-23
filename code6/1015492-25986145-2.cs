        public Form1()
        {
            InitializeComponent();
            
            if (dt.Minute % 30 > 15)
            {
                initialValue = true;
                dateTimePicker1.Value = dt.AddMinutes(dt.Minute % 30);
            }
            else
            {
                initialValue = true;
                dateTimePicker1.Value = dt.AddMinutes(-(dt.Minute % 30));
            }
            _prevDate = dateTimePicker1.Value;
        }
        private DateTime _prevDate;
        private bool initialValue = false;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(initialValue)
            {
                initialValue = false;
                return;
            }
            DateTime dt = dateTimePicker1.Value;
            TimeSpan diff = dt - _prevDate;
            if (diff.Ticks < 0) 
                dateTimePicker1.Value = _prevDate.AddMinutes(-30);
            else 
                dateTimePicker1.Value = _prevDate.AddMinutes(30);
            _prevDate = dateTimePicker1.Value;
        }
