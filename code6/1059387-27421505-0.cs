    public interface IHasSession
    {
        public Session Session { get; set; }
    }
    public static class HasSessionExtensions
    {
        public void SetSessionObject(this IHasSession haver, SessionObject value)
        {
            haver.Session["SessionObject"] = value;
        }
        public SessionObject GetSessionObject(this IHasSession haver)
        {
            return haver.Session["SessionObject"] as SessionObject;
        }
    }
