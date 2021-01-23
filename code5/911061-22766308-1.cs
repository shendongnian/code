        public void DrawPoint(Graphics G, Pen pen, Point point)
        {
            // add more LineCaps as needed..
            int pw2 = (int ) Math.Max(1, pen.Width / 2);
            using(var brush = new SolidBrush(){
                if (pen.EndCap == LineCap.Square)
                    G.FillRectangle(new SolidBrush(pen.Color), point.X - pw2, point.Y - pw2, pen.Width, pen.Width);
                else
                    G.FillEllipse(new SolidBrush(pen.Color), point.X - pw2, point.Y - pw2, pen.Width, pen.Width);
            }
        }
