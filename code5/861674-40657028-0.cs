        public static double ToDouble(this string value, double fallbackValue = 0)
        {
            double result;
            return double.TryParse(value, out result) ? result : fallbackValue;
        }
