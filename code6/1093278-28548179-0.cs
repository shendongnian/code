    public class StaticFunctions
    {
        public static string ConvertToQueryString<T>(T obj)
        {
            var keyPairs = typeof(T).GetProperties().Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(obj, null)));
            var sb = new StringBuilder();
            foreach (var item in keyPairs)
            {
                sb.Append(String.Format("{0}={1}&", item.Key, item.Value));
            }
            return "?" + sb.ToString().Substring(0, sb.Length - 1).ToLower(); //remove last &
        }
    }
