    List<Color> GetDistinctColors(Bitmap bmp)
    {
        List<Color> colors = new List<Color>();
        for (int y = 0; y < bmp.Height; y++)
            for (int x = 0; x < bmp.Width; x++)
            {
                Color c = bmp.GetPixel(x,y);
                if (!colors.Contains(c)) colors.Add(c);
            }
        return colors;
    }
    List<Color> ChangeColors(List<Color> colors)
    {
        List<Color> newColors = new List<Color>();
        foreach(Color c in colors)
        {
            int A = 255;   //  here you need..
            int R = c.G;   //  ..to write..
            int G = c.R;   //  ..your custom .
            int B = c.B;   //  ..color change code!!
            newColors.Add(Color.FromArgb(A,R,G,B));
        }
        return newColors;
    }
