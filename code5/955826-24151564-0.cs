    private void notifyUser_Load(object sender, EventArgs e)
        {
            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - 250, screen.WorkingArea.Bottom - 85);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            count++;
            if (count > 10)
            {
                count = 0;
                this.Close();
            }
        }
