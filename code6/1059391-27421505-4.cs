    public interface IHasSession
    {
        public Session Session { get; set; }
    }
    public static class HasSessionExtensions
    {
        public static void SetSessionObject(this IHasSession subject, SessionObject value)
        {
            subject.Session["SessionObject"] = value;
        }
        public static SessionObject GetSessionObject(this IHasSession subject)
        {
            return subject.Session["SessionObject"] as SessionObject;
        }
    }
