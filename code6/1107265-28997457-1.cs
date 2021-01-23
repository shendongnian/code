      Dictionary<Color, int> colors = new Dictionary<Color, int>();
      for (int iy = y; iy < y + 4; iy++)
        for (int ix = x; ix < x + 4; ix++)
         {
            Color c = default_image.GetPixel(ix,iy);
            if (colors.ContainsKey(c)) colors[c]++; else colors.Add(c, 1);
         }
        var vvv = colors.OrderByDescending(el => el.Value);
        MessageBox.Show(String.Format("Color {0} found {1} times.", 
                        vvv.First().Key, vvv.First().Value),  "Result");
