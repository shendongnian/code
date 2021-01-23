        private Timer t;
        private int step = 1;
        private void autohide()
        {
            t = new Timer();
            t.Interval = 2;
            t.Tick += T_Tick;
            t.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if (this.Location.X > 0 - this.Width)
            {
                this.Location = new Point(this.Location.X - step, this.Location.Y);
            }
            else
            {
                t.Stop();
            }
        }
