    public void draw(bool[] array)
    {
        Bitmap afbeelding = new Bitmap(resolutieX, resolutieY);
        for(int y = 0; y < resolutieY; y++)
        {
            for (int x = 0; x < resolutieX; x++)
            {
                if (array[y * resolutieX + x] == true)
                    afbeelding.SetPixel(x, y, Color.Black);
            }
        }
        pictureBox1.Image = afbeelding;
    }
