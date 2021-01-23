        public Bitmap CaptureFromScreen(Rectangle rect)
        {
            Bitmap bmpScreenCapture = null;
            if (rect == Rectangle.Empty)//capture the whole screen
            {
                bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            }
            else // just the rect
            {
                bmpScreenCapture = new Bitmap(rect.Width,rect.Height);
            }
            Graphics p = Graphics.FromImage(bmpScreenCapture);
            if (rect == Rectangle.Empty)
            { // captuer the whole screen
                p.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                         Screen.PrimaryScreen.Bounds.Y,
                                         0, 0,
                                         bmpScreenCapture.Size,
                                         CopyPixelOperation.SourceCopy);
            }
            else // cut a spacific rectangle
            {
                p.CopyFromScreen(rect.X,
                         rect.Y,
                         0, 0,
                         rect.Size,
                         CopyPixelOperation.SourceCopy);
            }
            return bmpScreenCapture;
        }
