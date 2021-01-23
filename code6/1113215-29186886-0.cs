            #region ============================Dragging============================
        private Point start = Point.Empty;
        private Point end = Point.Empty;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            start.X = e.X;
            start.Y = e.Y;
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            Point p1;
            Point p2;
            if (((e.Button & MouseButtons.Left) != 0) && (start != Point.Empty))
            {
                using (Graphics g = this.CreateGraphics())
                {
                    p1 = PointToScreen(start);
                    end.X = e.X;
                    end.Y = e.Y;
                    p2 = PointToScreen(end);
                    Console.WriteLine(end);
                }
            }
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            Point p1;
            Point p2;
            Console.WriteLine("Mouse Up");
            if ((end != Point.Empty) && (start != Point.Empty))
            {
                using (Graphics g = this.CreateGraphics())
                {
                    p1 = PointToScreen(start);
                    p2 = PointToScreen(end);
                    int x1 = p1.X;
                    int y1 = p1.Y;
                    int x2 = p2.X;
                    int y2 = p2.Y;
                    int x = x1 - x2;
                    int y = y1 - y2;
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    string[] xsp = x.ToString().Split('-');
                    string[] ysp = y.ToString().Split('-');
                    int rx = Convert.ToInt32(xsp[1]);
                    int ry = Convert.ToInt32(ysp[1]);
                    using (Bitmap bmpScreenCapture = new Bitmap(rx, ry, g))
                    {
                        using (Graphics gra = Graphics.FromImage(bmpScreenCapture))
                        {
                            gra.CopyFromScreen(x1, y1, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                            string filename = GenerateRandomString(20) + ".png";
                            bmpScreenCapture.Save(Path.GetTempPath() + "" + filename, ImageFormat.Png);
                            Upload(Path.GetTempPath() + "" + filename, filename);
                        }
                    }
                }
            }
            start = Point.Empty;
            end = Point.Empty;
        }
        #endregion
