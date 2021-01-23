    public IEnumerable<Rectangle> GetRectangles(Graphics g1)
    {
        int left = X;
        foreach (char ch in word)
        {
            
            //actual width is the (width of XX) - (width of X) to ignore padding
            var size = g1.MeasureString("" + ch, Font);
            var size2 = g1.MeasureString("" + ch + ch, Font);
    
            using (Bitmap b = new Bitmap((int)size.Width + 2, (int)size.Height + 2))
            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillRectangle(Brushes.White, 0, 0, size.Width, size.Height);
                g.TextRenderingHint = g1.TextRenderingHint;
                g.DrawString("" + ch, Font, Brushes.Black, 0, 0);
                int top = -1;
                int bottom = -1;
    
                //find the top row
                for (int y = 0; top < 0 && y < (int)size.Height - 1; y++)
                {
                    for (int x = 0; x < (int)size.Width; x++)
                    {
                        if (b.GetPixel(x, y).B < 2)
                        {
                            top = y;
                        }
                    }
                }
    
                //find the bottom row
                for (int y = (int)(size.Height - 1); bottom < 0 && y > 1; y--)
                {
                    for (int x = 0; x < (int)size.Width - 1; x++)
                    {
                        if (b.GetPixel(x, y).B < 2)
                        {
                            bottom = y;
                        }
                    }
                }
                yield return new Rectangle(left, Y + top, (int)(size2.Width - size.Width), bottom - top);
            }
            left += (int)(size2.Width - size.Width);
        }
    
    }
