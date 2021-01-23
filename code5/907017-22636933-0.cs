    public static class StrExt
    {
        public static double ToDouble(this string str)
        {
            double val;
            return Double.TryParse(str, out val) ? val : default(Double);
        }
    }
    ...
    valList = aList.Select(x => x.aDoubleValue_inString.ToDouble());
