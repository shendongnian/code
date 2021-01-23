    public static class MyExtensions
    {
        public static int ToInt32(this string value)
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
        public static int GetInt(this XmlNode node, string key)
        {
            var str = node.GetString(key);
            return str.ToInt32();
        }
        public static string GetString(this XmlNode node, string key)
        {
            if (node[key] == null || String.IsNullOrEmpty(node[key].InnerText))
                return null;
            else
                return node.InnerText;
        }
        // implement GetDateTime/GetDecimal as practice ;)
    }
