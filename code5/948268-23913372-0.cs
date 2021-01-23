        private const int ScrollIncrement = 10;
        private void ScrollUpButton_Click(object sender, EventArgs e) {
            int limit = 0;
            panel2.Location = new Point(0, 
                Math.Min(limit, panel2.Location.Y + ScrollIncrement));
        }
        private void ScrollDownButton_Click(object sender, EventArgs e) {
            int limit = panel1.ClientSize.Height - panel2.Height;
            panel2.Location = new Point(0, 
                Math.Max(limit, panel2.Location.Y - ScrollIncrement));
        }
