    public static class CookieExtensions
    {
        public static string DecodedValue(this HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException("cookie");
            }
            return HttpUtility.UrlDecode(cookie.Value);
        }
        public static void SetEncodedValue(this HttpCookie cookie, string value)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException("cookie");
            }
            cookie.Value = HttpUtility.UrlEncode(value);
        }
        public static string DecodedValues(this HttpCookie cookie, string name)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException("cookie");
            }
            return HttpUtility.UrlDecode(cookie.Values[name]);
        }
        public static void SetEncodedValues(this HttpCookie cookie, string name, string value)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException("cookie");
            }
            cookie.Values[name] = HttpUtility.UrlEncode(value);
        }
        public static string DecodedValues(this HttpCookie cookie, int index)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException("cookie");
            }
            return HttpUtility.UrlDecode(cookie.Values[index]);
        }
    }
