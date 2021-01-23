    // Description : Extension methods for using applying solid color in WinRT XAML projects.
    // Owner : Farhan Ghumra
    // Contact : https://www.facebook.com/farhan.ghumra
    //           https://twitter.com/_F4RH4N_
    // Example :
    // MyRectagle.Fill = ColorExtensions.FromName("SkyBlue");
    // MyTextBlock.Foreground = ColorExtensions.FromHex("#379988");
    
    using Windows.UI;
    using Windows.UI.Xaml.Media;
    using System.Reflection;
    
    namespace App1
    {
        public static class ColorExtensions
        {
            /// <summary>
            /// It gives solid color brush from hexadecimal color code.
            /// </summary>
            /// <param name="HexColor">Color code in hexadecimal format (Example : #123456 or #12345678)</param>
            /// <returns>New instance of SolidColorBrush accoiding to hexadecimal color.</returns>
            public static SolidColorBrush FromHex(string HexColor)
            {
                byte A, R, G, B;
    
                if (HexColor.Length == 7)
                {
                    A = 255;
                    R = HexColor.Substring(1, 2).ToByte();
                    G = HexColor.Substring(3, 2).ToByte();
                    B = HexColor.Substring(5, 2).ToByte();
                    return new SolidColorBrush(Color.FromArgb(A, R, G, B));
                }
    
                else if (HexColor.Length == 9)
                {
                    A = HexColor.Substring(1, 2).ToByte();
                    R = HexColor.Substring(3, 2).ToByte();
                    G = HexColor.Substring(5, 2).ToByte();
                    B = HexColor.Substring(7, 2).ToByte();
                    return new SolidColorBrush(Color.FromArgb(A, R, G, B));
                }
    
                else
                {
                    return new SolidColorBrush(Colors.Transparent);
                }
            }
    
            /// <summary>
            /// It gives solid color brush from color name.
            /// </summary>
            /// <param name="name">Color name as string.</param>
            /// <returns>New instance of SolidColorBrush according to color name.</returns>
            public static SolidColorBrush FromName(string ColorName)
            {
                var ColorProperty = typeof(Colors).GetRuntimeProperty(ColorName);
    
                if (ColorProperty != null)
                    return new SolidColorBrush((Color)ColorProperty.GetValue(null));
                else
                    return new SolidColorBrush(Colors.Transparent);
            }
    
            /// <summary>
            /// Converts hexadecimal color code channel (Alpha, Red, Blue, Green) to byte type.
            /// </summary>
            /// <param name="ColorCodePart">Hexadecimal color code channel (Alpha, Red, Blue, Green)</param>
            /// <returns>byte value parsed from Hexadecimal color code channel</returns>
            private static byte ToByte(this string ColorCodePart)
            {
                return byte.Parse(ColorCodePart, System.Globalization.NumberStyles.HexNumber);
            }
        }
    }
