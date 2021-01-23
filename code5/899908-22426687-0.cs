      private Microsoft.Xna.Framework.Color ConvertFromHex(string s)
        {
            if (s.Length != 7)
                return Color.Gray;
    
            int r = Convert.ToInt32(s.Substring(1, 2), 16);
            int g = Convert.ToInt32(s.Substring(3, 2), 16);
            int b = Convert.ToInt32(s.Substring(5, 2), 16);
            return new Color(r, g, b);
        }
