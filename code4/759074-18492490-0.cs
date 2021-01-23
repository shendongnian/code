        private void paintEvent(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            // Draw a line in the PictureBox.
            g.DrawLine(System.Drawing.Pens.Red, 50, 50,
                51, 51);
            g.DrawRectangle(System.Drawing.Pens.Red, 50, 50, 1, 1);
            
        }
