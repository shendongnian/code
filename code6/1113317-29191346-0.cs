    #region testing
        private Point start = Point.Empty;
        private Point end = Point.Empty;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                start.X = e.X;
                start.Y = e.Y;
            }
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            //this.Invalidate();
            Point p1;
            Point p2;
            if (((e.Button & MouseButtons.Left) != 0) && (start != Point.Empty))
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.Clear(this.BackColor);
                    p1 = PointToScreen(start);
                    if (end != Point.Empty)
                    {
                        p2 = PointToScreen(end);
                        ControlPaint.DrawReversibleFrame(GetRectangleForPoints(p1, p2), Color.Black, FrameStyle.Dashed);
                    }
                    end.X = e.X;
                    end.Y = e.Y;
                    p2 = PointToScreen(end);
                    ControlPaint.DrawReversibleFrame(GetRectangleForPoints(p1, p2), Color.Black, FrameStyle.Dashed);
                }
            }
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            Point p1;
            Point p2;
            if ((end != Point.Empty) && (start != Point.Empty))
            {
                using (Graphics g = this.CreateGraphics())
                {
                    p1 = PointToScreen(start);
                    p2 = PointToScreen(end);
                    ControlPaint.DrawReversibleFrame(GetRectangleForPoints(p1, p2), Color.Black, FrameStyle.Dashed);
                    int x1 = p1.X;
                    int y1 = p1.Y;
                    int x2 = p2.X;
                    int y2 = p2.Y;
                    int x = x2 - x1;
                    int y = y2 - y1;
                    
                    string[] xsp;
                    int rx = 0;
                    string[] ysp;
                    int ry = 0;
                    if (x.ToString().Contains("-"))
                    {
                        xsp = x.ToString().Split('-');
                        rx = Convert.ToInt32(xsp[1]);
                    }
                    else
                    {
                        rx = x;
                    }
                    if (y.ToString().Contains("-"))
                    {
                        ysp = y.ToString().Split('-');
                        ry = Convert.ToInt32(ysp[1]);
                    }
                    else
                    {
                        ry = y;
                    }
                    
                    using (Bitmap bmpScreenCapture = new Bitmap(rect.Width, rect.Height, g))
                    {
                        using (Graphics gra = Graphics.FromImage(bmpScreenCapture))
                        {
                            gra.CopyFromScreen(rect.X, rect.Y, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                            string filename = GenerateRandomString(20) + ".png";
                            bmpScreenCapture.Save(Path.GetTempPath() + "" + filename, ImageFormat.Png);
                            g.Clear(this.BackColor);
                            //Upload(Path.GetTempPath() + "" + filename, filename);
                        }
                    }
                }
            }
            start = Point.Empty;
            end = Point.Empty;
        }
        private Rectangle GetRectangleForPoints(Point beginPoint, Point endPoint)
        {
            int top = beginPoint.Y < endPoint.Y ? beginPoint.Y : endPoint.Y;
            int bottom = beginPoint.Y > endPoint.Y ? beginPoint.Y : endPoint.Y;
            int left = beginPoint.X < endPoint.X ? beginPoint.X : endPoint.X;
            int right = beginPoint.X > endPoint.X ? beginPoint.X : endPoint.X;
            rect = new Rectangle(left, top, (right - left), (bottom - top));
            return rect;
        }
        #endregion
