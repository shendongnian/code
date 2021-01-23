    public static class ColorEx
    {
        public static string GetColorName(this SolidColorBrush scb)
        {
            return typeof(Colors).GetRuntimeProperties().Where(x => (Color)x.GetValue(null) == scb.Color).Select(x => x.Name).FirstOrDefault();
        }
    }
