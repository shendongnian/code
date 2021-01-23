        if (TabControlMain.SelectedIndex == e.Index)
            using (Pen pen = new Pen(Color.Gray))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(-3,-2);
                e.Graphics.DrawRectangle(pen, rect);
            }
