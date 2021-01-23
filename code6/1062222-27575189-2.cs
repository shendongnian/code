    public static class ExtensionSymitar
    {
        public static List<string> ValueList(this string source, string fieldType)
        {
            var list = source.Split('~').ToList();
            return list.Where(a => a.StartsWith(fieldType)).ToList();
        }
        public static string KeyValuePairs(this string source, string fieldType)
        {
            return source.ValueList(fieldType).Aggregate(string.Empty, (current, j) => string.Format("{0}~{1}", current, j));
        }
        public static bool IsMultiRecord(this string source, string fieldType)
        {
            return source.ValueList(fieldType)
                            .Select(q => new Regex(Regex.Escape(q.Split('=').First())).Matches(source).Count > 1).First();
        }
    
        public static int ParseInt(this string val, string keyName)
        {
            int newValue;
            if (!int.TryParse(val, out newValue))
                throw new Exception("Could not parse " + keyName + " as an integer!");
            return newValue;
        }
        public static decimal ParseMoney(this string val, string keyName)
        {
            decimal newValue;
            if (!decimal.TryParse(val, out newValue))
                throw new Exception("Could not parse " + keyName + " as a money amount!");
            return newValue;
        }
        public static DateTime? ParseDate(this string val, string keyName)
        {
            if (val.Equals("00000000")) return null;
    
            var year = val.Substring(0, 4).ToInt();
            var mon = val.Substring(4, 2).ToInt();
            var day = val.Substring(6, 2).ToInt();
    
            if (year <= 1800 || year >= 2200 || mon < 1 || mon > 12 || day < 1 || day > 31)
                throw new Exception("Could not parse " + keyName + " as a date!");
    
            return new DateTime(year, mon, day);
        }
    }
