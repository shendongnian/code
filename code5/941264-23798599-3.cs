    public class Handler1 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(GetXmlReceiptFromContext(context));
            context.Response.Write("</ br>");
            context.Response.Write(GetXmlReceiptFromContext(context));
        }
        //returns the xml document as string
        private static string GetXmlReceiptFromContext(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();
            context.Response.Cache.SetExpires(DateTime.MinValue);
            return RawPostValues(context)
                .SingleOrDefault(kvp => kvp.Key.Equals("status", StringComparison.InvariantCultureIgnoreCase))
                .Value;
        }
        private static IEnumerable<KeyValuePair<string, string>> RawPostValues(HttpContext context)
        {
            if (context.Request.HttpMethod != "POST") yield break;
            var tmpPosition = context.Request.InputStream.Position;
            string[] formElements;
            try
            {
                formElements = System.Text.Encoding.Default.GetString(
                    context.Request.BinaryRead(context.Request.ContentLength))
                    .Split('&');
                if (formElements.Length < 1) yield break;
            }
            finally
            {
                context.Request.InputStream.Position = tmpPosition;
            }
            foreach (var element in formElements)
            {
                if (string.IsNullOrEmpty(element)) continue;
                var key = element.Substring(0, element.IndexOf('='));
                var value = element.Substring(key.Length + 1, element.Length - key.Length - 1);
                yield return new KeyValuePair<string, string>(key, value);
            }
        }
    }
