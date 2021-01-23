        Point startPoint = new Point(0, 0);
        Point endPoint = new Point(1, 1);
        bool mousePress = false;
        control.MouseDown += (s, e) =>
        {
                startPoint = new Point(e.X,e.Y);
                mousePress = true;
        };
        control.MouseUp += (s, e) =>
        {
                mousePress = false;
        };
        control.MouseMove += (s, e) =>
        {
                if (mousePress)
                {
                    endPoint = new Point(e.X, e.Y);
                    control.Invalidate();
                }
        };
        control.Paint += (s, e) =>
        {
                Graphics g = e.Graphics;
                g.DrawRectangle(Pens.Black, new Rectangle(startPoint.X, startPoint.Y,endPoint.X-startPoint.X, endPoint.Y-startPoint.Y));
        };
