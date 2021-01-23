    using Windows.UI.Xaml.Markup;
    ....
     static class ColorUtils
        {
            public static Color GetColorFromHex(string hexString)
            {
                Color x =(Color)XamlBindingHelper.ConvertValue(typeof(Color), hexString);
                return x;
            }
        }
