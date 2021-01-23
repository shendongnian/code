    using System.Reflection;     // For GetRuntimeProperty
    using System.Globalization;  // For NumberStyles
    using Windows.UI;            // for Color and Colors
    using Windows.UI.Xaml.Media; // for SystemColorBrush
    // from #AARRGGBB string
    byte a = byte.Parse(hexColor.Substring(1, 2),NumberStyles.HexNumber);
    byte r = byte.Parse(hexColor.Substring(3, 2),NumberStyles.HexNumber);
    byte g = byte.Parse(hexColor.Substring(5, 2),NumberStyles.HexNumber);
    byte b = byte.Parse(hexColor.Substring(7, 2),NumberStyles.HexNumber);
    
    Windows.UI.Color color = Color.FromArgb(a, r, g, b);
    Windows.UI.Xaml.Media.SolidColorBrush br = new SolidColorBrush(color);
    // From Name
    var prop = typeof(Windows.UI.Colors).GetRuntimeProperty("Aqua");
    if (prop != null)
    {
        Color c = (Color) prop.GetValue(null);
        br = new SolidColorBrush(c);
    }
    // From Property
    br = new SolidColorBrush(Colors.Aqua);
