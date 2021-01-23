        Point downPoint;
        //MouseDown event handler for your pictureBox1
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e){
            downPoint = e.Location;
            pictureBox1.Parent = this;
            pictureBox1.BringToFront();
        }
        //MouseMove event handler for your pictureBox1
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left) {
                pictureBox1.Left += e.X - downPoint.X;
                pictureBox1.Top += e.Y - downPoint.Y;
            }
        }
        //MouseUp event handler for your pictureBox1
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            Control c = GetChildAtPoint(new Point(pictureBox1.Left - 1, pictureBox1.Top));
            if (c == null) c = this;
            Point newLoc = c.PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
            pictureBox1.Parent = c;
            pictureBox1.Location = newLoc;
        }
    
