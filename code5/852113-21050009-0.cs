        int currentDotCount = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDotCount = Convert.ToInt32(comboBox1.SelectedItem);
            panel2.Refresh();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            randomPaint(currentDotCount, (Panel)sender, e.Graphics);
        }
        private void randomPaint(int numberOfTimes, Panel p, Graphics g)
        {
            Random r = new Random();
            for (int i = 0; i < numberOfTimes; i++)
            {
                using (var b1 = new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))))
                {
                    g.FillEllipse(b1, r.Next(p.Size.Width), r.Next(p.Size.Height), 30, 30);
                }
            }
        }
