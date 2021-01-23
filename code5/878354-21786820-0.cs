       static class QueryStringBuilder {
    
          public static string ToQueryString(this NameValueCollection qs) {
             return ToQueryString(qs, includeDelimiter: false);
          }
    
          public static string ToQueryString(this NameValueCollection qs, bool includeDelimiter) {
    
             var sb = new StringBuilder();
    
             for (int i = 0; i < qs.AllKeys.Length; i++) {
    
                string key = qs.AllKeys[i];
                string[] values = qs.GetValues(key);
    
                if (values != null) {
                   for (int j = 0; j < values.Length; j++) {
    
                      if (sb.Length > 0)
                         sb.Append('&');
    
                      sb.Append(HttpUtility.UrlEncode(key))
                         .Append('=')
                         .Append(HttpUtility.UrlEncode(values[j]));
                   }
                }
             }
    
             if (includeDelimiter && sb.Length > 0)
                sb.Insert(0, '?');
    
             return sb.ToString();
          }
       }
