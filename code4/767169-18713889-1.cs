    public static class CSVConverter
    {
        public static string ToCsv<T>(this IEnumerable<T> items) where T : class
        {
            var csvBuilder = new StringBuilder();
            var properties = typeof(T).GetProperties();
            if (properties.Count() == 0)
            {
                csvBuilder.AppendLine(String.Join(",", items));
            }
            else
            {
                csvBuilder.AppendLine(String.Join(",", properties.Select(p => p.Name.ToCsvValue()).ToArray()));
                foreach (T item in items)
                {
                    string line = String.Join(",", properties.Select(p => p.GetValue(item, null).ToCsvValue()).ToArray());
                    csvBuilder.AppendLine(line);
                }
            }
            return csvBuilder.ToString();
        }
        private static string ToCsvValue<T>(this T item) where T : class
        {
            if (item == null) { return ""; }
            if (item is string)
            {
                return String.Format("\"{0}\"", item.ToString().Replace("\"", "\""));
            }
            if (item.GetType().IsArray)
            {
                return item.ToString() + "\"" + ((IEnumerable<T>)item).ToCsv() + "\"";
            }
            double dummy;
            if (double.TryParse(item.ToString(), out dummy))
            {
                return String.Format("{0}", item);
            }
            return String.Format("\"{0}\"", item);
        }
    }
