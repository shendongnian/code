    public void draw(Array array)
    {
        Bitmap afbeelding = new Bitmap(resolutieX, resolutieY,
                                       PixelFormat.Format1bppIndexed);
        for(int y = 0; y < resolutieY; y++)
        {
            for (int x = 0; x < resolutieX; x++)
            {
                if (array[y * resolutieX + x] == 1)
                    afbeelding.SetPixel(x, y, Color.Black);
            }
        }
        pictureBox1.Image = afbeelding;
    }
