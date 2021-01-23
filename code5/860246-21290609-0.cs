            // Create your bitmap - 100x100 pixels for example
            using (Bitmap b = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White); // White background
                    using (FontFamily fontFamily = new FontFamily("Arial"))
                    {
                        using (Font font = new Font(fontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel))
                        {
                            using (SolidBrush solidBrush = new SolidBrush(Color.Red)) // Red text
                            {
                                g.DrawString("A", font, solidBrush, new PointF(10, 10)); // Draw an "A" at position 10,10
                            }
                        }
                    }
                }
            }
        }
