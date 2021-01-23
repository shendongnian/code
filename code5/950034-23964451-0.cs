            Point first = new Point(20, 40);
            Point second = new Point(100, 40);
            string str = "test";
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Size s = TextRenderer.MeasureText(str,this.Font);
                double middle = (second.X + first.X) / 2;
                e.Graphics.DrawLine(Pens.Black, first,second);
                TextRenderer.DrawText(e.Graphics, str, this.Font, new Point((int)(middle - (s.Width / 2)), first.Y - s.Height), Color.Red);
            }
