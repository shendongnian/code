    static class Util
    {
        public static string conversion(string ConvertIn, string ConvertOut, string Value)
        {
            double c1 = double.Parse(ConvertIn),
                c2 = double.Parse(ConvertOut),
                v = double.Parse(Value);
            return ((v / c1) * c2).ToString();
        }
    }
