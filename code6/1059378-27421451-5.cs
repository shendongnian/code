    public interface ISessionContainer{}
    
    public static class SessionExtensions
    {
        public SessionObject GetSessionObject(this ISessionContainer session)
        {
            return session["SessionObject"] as SessionObject;
        }
    
        public SessionObject SetSessionObject(
                this ISessionContainer session, 
                SessionObject obj)
        {
            session["SessionObject"] = sessionObject;
        }
    
    }
    
    public class YourClass1 : ISessionContainer{}
