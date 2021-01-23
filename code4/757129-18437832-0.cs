        Point downPoint;
        //MouseDown event handler for your label1
        private void label1_MouseDown(object sender, MouseEventArgs e){
            downPoint = e.Location;
            //this is the most important code to make it works
            Cursor.Clip = yourPanel.RectangleToScreen(new Rectangle(e.X, e.Y, yourPanel.ClientSize.Width - label1.Width, yourPanel.ClientSize.Height - label1.Height));
        }
        //MouseMove event handler for your label1
        private void label1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                label1.Left += e.X - downPoint.X;
                label1.Top += e.Y - downPoint.Y;
            }
        }
        //MouseUp event handler for your label1
        private void label1_MouseUp(object sender, MouseEventArgs e){
            Cursor.Clip = Rectangle.Empty;
        }
