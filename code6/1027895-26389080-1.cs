     public Bitmap pSetInvert(Bitmap _currentBitmap)
            {
                using (var bmap = FastImage.Create(_currentBitmap))
                {
                    Parallel.For(0, bmap.Width, i =>
                    {
                        for (int j = 0; j < bmap.Height; j++)
                        {
                            var c = bmap.GetPixel(i, j);
                            bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
    
                        }
                    });
                    return bmap.ToBitmap();
                }
            }
