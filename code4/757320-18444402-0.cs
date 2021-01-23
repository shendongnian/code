    public class SessionProvider
    {
        
        public static void Put(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static void PutObject(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static void Delete(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public static string Get(string key)
        {
            if (HttpContext.Current.Session[key] == null)
                return null;
            else
                return HttpContext.Current.Session[key].ToString();
        }
        public static object GetObject(string key)
        {
            return HttpContext.Current.Session[key];
        }
        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
