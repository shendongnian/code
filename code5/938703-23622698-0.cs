    public class ColorHelper
        {
            public static object HexToBrush(string value)
            {
                byte alpha;
                byte pos = 0;
                string hex = value.ToString().Replace("#", "");
    
                if (hex.Length == 8)
                {
                    alpha = System.Convert.ToByte(hex.Substring(pos, 2), 16);
                    pos = 2;
                }
                else
                {
                    alpha = System.Convert.ToByte("ff", 16);
                }
    
                byte red = System.Convert.ToByte(hex.Substring(pos, 2), 16);
    
                pos += 2;
                byte green = System.Convert.ToByte(hex.Substring(pos, 2), 16);
    
                pos += 2;
                byte blue = System.Convert.ToByte(hex.Substring(pos, 2), 16);
    
                return new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
            }
    
            public static object BrushToHex(object value)
            {
                SolidColorBrush val = value as SolidColorBrush;
                return "#" + val.Color.A.ToString() + val.Color.R.ToString() + val.Color.G.ToString() + val.Color.B.ToString();
            }
        }
