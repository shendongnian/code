        private void OutsideBusinessHoursTimer_Tick(object sender, EventArgs e)
        {
            int x = r.Next(0, this.ClientRectangle.Width - this.pbLifebrokerInactive.Width);
            int y = r.Next(0, this.ClientRectangle.Height - this.pbLifebrokerInactive.Height);
            this.pbLifebrokerInactive.Location = new Point(x, y);
        }
