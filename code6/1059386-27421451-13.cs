    public interface ISessionContainer{}
    
    public static class SessionExtensions
    {
        public static SessionObject GetSessionObject(this ISessionContainer session)
        {
            return session["SessionObject"] as SessionObject;
        }
    
        public static void SetSessionObject(this ISessionContainer session, 
                                                    SessionObject obj)
        {
            session["SessionObject"] = obj;
        }
    
    }
    
    public class YourClass1 : ISessionContainer{}
    public class YourClass2 : ISessionContainer{}
