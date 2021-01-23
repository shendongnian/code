      Dictionary<Color, int> colors = new Dictionary<Color, int>();
      for (int y = 0; y < default_image.Height; y++)
        for (int x = 0; x < default_image.Width; x++)
         {
            Color c = default_image.GetPixel(x,y);
            if (colors.ContainsKey(c)) colors[c]++; else colors.Add(c, 1);
         }
        var vvv = colors.OrderByDescending(el => el.Value);
        MessageBox.Show(String.Format("Color {0} found {1} times.", 
                        vvv.First().Key, vvv.First().Value),  "Result");
