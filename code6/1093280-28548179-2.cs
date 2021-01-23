    public static class ObjectExtensions
    {
        public static string ToQueryString(this Object obj)
        {
            var keyPairs = obj.GetType().GetProperties().Select(p =>
                new KeyValuePair<string, object>(p.Name.ToLower(), p.GetValue(obj, null)));
            var arr = new List<string>();
            foreach (var item in keyPairs)
            {
                if (item.Value is IEnumerable)
                {
                    foreach (var arrayItem in (item.Value as IEnumerable))
                    {
                        arr.Add(String.Format("{0}={1}", item.Key, arrayItem.ToString().ToLower()));
                    }
                }
                else
                    arr.Add(String.Format("{0}={1}", item.Key, item.Value.ToString().ToLower()));
            }
            return "?" + String.Join("&", arr);
        }
    }
