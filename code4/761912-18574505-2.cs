    public static class StringHelper
    {
        public static string Center(this String value, int width)
        {
            var padding = (width + value.Length) / 2;
            return value.PadLeft(padding, '#');
        }
    }
