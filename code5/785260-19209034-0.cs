        private void panel1_Paint(object sender, PaintEventArgs e) {
            using (var myPen = new Pen(Color.Black, 1)) {
                e.Graphics.DrawLine(myPen, new Point(5, 5), new Point(100, 100));
                e.Graphics.DrawEllipse(myPen, 0, 0, 90, 90);
            }
        }
