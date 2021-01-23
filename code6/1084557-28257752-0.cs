        public static void FadeColor(DMXController controller, Color startColor, Color endColor, double accuracy = 1)
        {
            Thread fadeColorThread = new Thread(delegate()
            {
                Color color = Color.Empty;
                using (Bitmap bmp = new Bitmap((int)(256 * accuracy), 1))
                {
                    using (Graphics gfx = Graphics.FromImage(bmp))
                    {
                        using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(bmp.Width, bmp.Height), startColor, endColor))
                        {
                            gfx.FillRectangle(brush, brush.Rectangle);
                            controller.SetColor(startColor);
                                
                            for (int i = 0; i < bmp.Width; i++)
                                controller.SetColor(bmp.GetPixel(i, 0));
                            controller.SetColor(endColor);
                        }
                    }
                }
            });
            fadeColorThread.Name = "DMX Color Transition Thread";
            fadeColorThread.Start();
        }
