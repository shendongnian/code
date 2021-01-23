        void PNL_TitleBar_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
                return;
            using (Brush gradientBrush = new LinearGradientBrush(new Point(0, 0),
                                  new Point((int)e.ClipRectangle.Right, 0),
                                  Color.Gray,
                                  Color.FromArgb(255, 50, 50, 50)))
            using (Pen gradientPen = new Pen(gradientBrush))
            {
                e.Graphics.DrawLine(gradientPen,
                                    new Point((int)e.ClipRectangle.Left, (int)e.ClipRectangle.Bottom - 1),
                                    new Point((int)e.ClipRectangle.Right, (int)e.ClipRectangle.Bottom - 1));
            }
        }
