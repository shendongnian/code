    private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int l = rnd.Next(1,545);
            RD[ndrop] = new PictureBox();
            RD[ndrop].BackColor = System.Drawing.Color.MediumBlue;
            RD[ndrop].Size = new Size(5, 5);
            RD[ndrop].Location = new Point(l, 0);
            RD[ndrop].LocationChanged += pb_LocationChanged;
            this.Controls.Add(RD[ndrop]);
            ndrop++;
            dropIt();
        }
    void pb_LocationChanged(object sender, EventArgs e)
        {
            // FORM_LASTBOUND is the Y-Axis point after which you wanted to remove the picturebox.
            if ((sender as PictureBox).Top > FORM_LASTBOUND)
            {
                this.Controls.Remove(sender as PictureBox);
            }
            
        }
