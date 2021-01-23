     Bitmap ResizeMyImage(Bitmap Source, int scalefactor)
            {
                int newHeight = Source.Height / scalefactor;
                int newWidth = (int)(Source.Width * (newHeight / (float)Source.Height));
                ResizeBilinear filter = new ResizeBilinear(newWidth, newHeight);
                return filter.Apply(Source);
            }
