    public static class StringExt
        {
            public static double ParseDouble(this string value)
            {
                double result;
                Double.TryParse(value, out result);
                return result;
            }
            
        }
