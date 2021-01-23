    public static class ColorEx
    {
        public static string GetColorName(this SolidColorBrush scb)
        {
            string result = null;
            foreach (var pi in typeof(Colors).GetRuntimeProperties())
            {
                Color c = (Color)pi.GetValue(null);
                if (c == scb.Color)
                {
                    result = pi.Name;
                    break;
                }
            }
            return result;
        }
    }
