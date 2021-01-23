    public class Cookies : ICookies
    {
        public string this[string name]
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies[name];
                if (cookie == null)
                    throw new KeyNotFoundException();
                return cookie.Value;
            }
            set
            {
                var cookie = HttpContext.Current.Request.Cookies[name];
                if (cookie == null)
                    throw new KeyNotFoundException();
                cookie.Value = value;
            }
        }
    }
