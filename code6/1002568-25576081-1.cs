        private void Form1_Load(object sender, EventArgs e)
        {
            // To update the first time.
            label1.Text = (DateTime.Today.AddDays(1)- DateTime.Now).ToString(@"hh\:mm\:ss");
            var timer = new Timer {Interval = 1000};
            timer.Tick += (o, args) =>
            {
                label1.Text = (DateTime.Today.AddDays(1)- DateTime.Now).ToString(@"hh\:mm\:ss");
            };
            timer.Start();
        }
