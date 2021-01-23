            // inside OnPaint
            // overlay
            using (Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics gtemp = Graphics.FromImage(bmp))
                {
                    // fake glowing
                    using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 255, 255, 255), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical))
                    {
                        brush.SetBlendTriangularShape(0.5f, 1.0f);
                        gtemp.FillPath(brush, path);
                    }
                    // draw on screen
                    e.Graphics.DrawImage(bmp, 0, 0);
                }
            }
