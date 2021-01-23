        public static WriteableBitmap ChangeColor(WriteableBitmap writeableBitmapOriginal, Color originalColor, Color newColor)
        {
            var writeableBitmapNew = new WriteableBitmap(writeableBitmapOriginal);
            for (int i = 0; i < writeableBitmapNew.PixelWidth; i++)
            {
                for (int j = 0; j < writeableBitmapNew.PixelHeight; j++)
                {                    
                    if (writeableBitmapOriginal.GetPixel(i, j).Equals(originalColor))
                    {
                        writeableBitmapNew.SetPixel(i, j, newColor);
                    }
                }
            }
            return writeableBitmapNew;
        }  
