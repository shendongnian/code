        bool isDragged = false;
        Point ptOffset;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragged = true;
                Button btn = (Button)sender;
                ptOffset = new Point(btn.Location.X - Cursor.Position.X, btn.Location.Y - Cursor.Position.Y);
            }
            else
            {
                isDragged = false;
            }
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = Cursor.Position;
                newPoint.Offset(ptOffset);
                Button btn = (Button)sender;
                btn.Location = newPoint;
            }
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;
        }
