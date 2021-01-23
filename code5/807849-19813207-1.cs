    public IEnumerable<Color> DistinctColors(int n)
    {
        int m = (int)Math.Ceiling(Math.Pow(n, 1/3.0));
        for (int green = 0; green <= m; ++green)
        {
            for (int blue = 0; blue <= m; ++blue)
            {
                for (int red = 0; red <= m; ++red)
                {
                    if (n-- == 0)
                        yield break;
                    int r = (int)(0.5 + red*255.0/m);
                    int g = (int)(0.5 + green*255.0/m);
                    int b = (int)(0.5 + blue*255.0/m);
                    yield return Color.FromArgb(r, g, b);
                }
            }
        }
    }
