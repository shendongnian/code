c#
public interface ICookies
{
	string this[key name]{ get; set; }
}
And then, you can create the humble class, which isn't under test.
c#
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
Your target class will be changed as below.
c#
public static class CookieManager
{
    public static void Write(ICookies cookies, string name, string value)
    {
        ...
    }
}
