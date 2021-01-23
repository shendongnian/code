    public static class Util
    {
        public static double? TryParse(string source)
        {
            double x;
            if (double.TryParse(source, out x))
                return x;
            return null;
        }
    }
