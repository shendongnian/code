    public static class MyExtensions
    {
        public static long ToInt32(this string value)
        {
            Int32 result = 0;
            if (!string.IsNullOrEmpty(value))
                Int32.TryParse(value, out result);
            return result;
        }
        public static decimal ToDecimal(this string value)
        {
            Decimal result = 0M;
            if (!string.IsNullOrEmpty(value))
                Decimal.TryParse(value, out result);
            return result;
        }
        public static string ValueOrEmpty(this XmlNode node)
        {
            if (node == null || String.IsNullOrEmpty(node.InnerText))
                return null;
            else
                return node.InnerText;
        }
        // implement DateTime as practice ;)
    }
