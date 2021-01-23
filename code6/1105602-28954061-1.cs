        namespace YourNamespaceHere
        {
            using System;
            using Windows.UI;
            using Windows.UI.Xaml.Data;
            using Windows.UI.Xaml.Media;
    
            public class HexToColorConverter : IValueConverter
            {
                /// <summary>
                /// Converts a hexadecimal string value into a Brush.
                /// </summary>
                public object Convert(object value, Type targetType, object parameter, string language)
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
        
                /// <summary>
                /// And back again.
                /// </summary>
                public object ConvertBack(object value, Type targetType, object parameter, string language)
                {
                    SolidColorBrush val = value as SolidColorBrush;
                    return "#" + val.Color.A.ToString() + val.Color.R.ToString()  + val.Color.G.ToString() +  val.Color.B.ToString();
                }
            }
        }
