        private void SetTimer() {
            var now = DateTime.Now;
            var next = new DateTime(now.Year, now.Month, now.Day).AddHours(now.Hour + 1);
            var msec = (next - now).TotalMilliseconds;
            timer1.Interval = (int)msec;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            SetTimer();
            // etc...
        }
