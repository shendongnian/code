            int width = this.Width; // get the width of Form.
            if(pictureBox1.Location.X > width - pictureBox1.Width) //to check condition if pic box is touch the boundroy of form width
            {
                pictureBox1.Location = new Point(1, pictureBox1.Location.Y); // pic box is set to the new point. here 1 is indicate of X coordinate.
            }
            else
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 100, pictureBox1.Location.Y); // to move picture box from x coordinate by 100 Point.
            }
            
        }
