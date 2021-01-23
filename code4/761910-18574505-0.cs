    public static class StringHelper
    {
        public static string Center(this String value, int width)
        {
           var centerLineTemplate = width / 2;
           var centerString = value.Length / 2;
           var padding = (centerLineTemplate + centerString) / 2;
           return value.PadLeft(padding);
        }
    }
