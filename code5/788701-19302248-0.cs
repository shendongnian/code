        bool suppressMouseLeave;
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            suppressMouseLeave = true;
            this.pictureBox1.Size = new Size(500, 500);
            pictureBox1.Location = new Point(this.Bounds.Width / 2,
                            this.Bounds.Height / 2);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BringToFront();
            //point the cursor to the new Position so that it's still kept on the pictureBox1
            //This is important because it makes your idea acceptable.
            //Otherwise you have to move your mouse onto your pictureBox and leave the 
            //mouse from it then to restore the pictureBox
            Cursor.Position = PointToScreen(new Point(pictureBox1.Left + 250, pictureBox1.Top + 250));
            suppressMouseLeave = false;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if(suppressMouseLeave) return;
            this.pictureBox1.Size = new Size(100, 100);
            pictureBox1.Location = new Point(12, 27);
        }
