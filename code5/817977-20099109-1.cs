        int interval = 120;
        List<Color> colors = new List<Color>();
        for (int red = 0; red < 255; red += interval)
        {
            for (int green = 0; green < 255; green += interval)
            {
                for (int blue = 0; blue < 255; blue += interval)
                {
                    if (red > 150 | blue > 150 | green > 150 ) //to make sure color is not too dark
                    {
                        colors.Add(Color.FromARGB(Color.FromArgb(255, (byte)(red), (byte)(green), (byte)(blue));
                    }
                }
             }
         }
         var sortedColors = colors.OrderBy(c => c.GetHue())
                                  .ThenBy(c => c.GetSaturation())
                                  .ThenBy(c => c.GetBrightness());
         foreach (Color c in sortedColors)
         {                        
             ComboBoxItem item = new ComboBoxItem {
                 Background = new SolidColorBrush(c),
                 Content = string.Format("#{0:X8}", c.ToArgb())
             };
             cmbColors.Items.Add(item);
         }
