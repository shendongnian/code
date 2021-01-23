    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public static class CollectionExtensions {
        public static string ToQueryString(this IDictionary<string, string> dict)
        {
        if (dict.Count == 0) return string.Empty;
        var buffer = new StringBuilder();
        int count = 0;
        bool end = false;
        foreach (var key in dict.Keys)
        {
            if (count == dict.Count - 1) end = true;
            if (end)
                buffer.AppendFormat("{0}={1}", key, dict[key]);
            else
                buffer.AppendFormat("{0}={1}&", key, dict[key]);
            count++;
        }
        return buffer.ToString();
    }
    }
