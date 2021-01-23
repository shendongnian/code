        private int direction = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            direction = direction * -1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            picturebox.Left += direction * 10;
            if (!this.ClientRectangle.IntersectsWith(picturebox.Bounds))
            {
                if (direction == -1)
                    picturebox.Left = this.ClientRectangle.Width;
                else
                    picturebox.Left = -picturebox.Width;
            }
        }
