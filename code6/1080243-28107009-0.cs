    public static string ToQueryString(string url, NameValueCollection nvc)
        {
            StringBuilder sb;
            if (url.Contains("?"))
                sb = new StringBuilder("&");
            else
                sb = new StringBuilder("?");
            bool first = true;
            foreach (string key in nvc.AllKeys)
            {
                foreach (string value in nvc.GetValues(key))
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                    first = false;
                }
            }
            return url + sb.ToString();
        }
