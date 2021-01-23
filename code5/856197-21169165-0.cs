    public static class UriExtensions
    {
        public static Uri CreateUriWithQuery(Uri uri, NameValueCollection values)
        {
            var queryStr = new StringBuilder();
            // presumes that if there's a Query set, it starts with a ?
            var str = string.IsNullOrWhiteSpace(uri.Query) ?
                      "" : uri.Query.Substring(1) + "&";
    
            foreach (var value in values)
            {
                queryStr.Append(str + value.Key + "=" + value.Value);
                str = "&";
            }
            // query string will be encoded by building a new Uri instance...
            // assumes that there already isn't a querystring
            return new UriBuilder(uri)
            {
                Query = queryStr.ToString()
            }.Uri;
        }
    }
    public class NameValueCollection : Dictionary<string, string> 
    {
    }
