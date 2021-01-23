    private Color ConvertHexStringToColour(string hexString)
    {
      byte a = 0;
      byte r = 0;
      byte g = 0;
      byte b = 0;
      if (hexString.StartsWith("#"))
      {
        hexString = hexString.Substring(1, 8);
      }
      a = Convert.ToByte(Int32.Parse(hexString.Substring(0, 2), 
          System.Globalization.NumberStyles.AllowHexSpecifier));
      r = Convert.ToByte(Int32.Parse(hexString.Substring(2, 2), 
          System.Globalization.NumberStyles.AllowHexSpecifier));
      g = Convert.ToByte(Int32.Parse(hexString.Substring(4, 2), 
          System.Globalization.NumberStyles.AllowHexSpecifier));
      b = Convert.ToByte(Int32.Parse(hexString.Substring(6, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
      return Color.FromArgb(a, r, g, b);
    }
