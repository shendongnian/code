    public interface IHasSession
    {
        public Session Session { get; set; }
    }
    public static class HasSessionExtensions
    {
        public void SetSessionObject(this IHasSession subject, SessionObject value)
        {
            subject.Session["SessionObject"] = value;
        }
        public SessionObject GetSessionObject(this IHasSession subject)
        {
            return subject.Session["SessionObject"] as SessionObject;
        }
    }
