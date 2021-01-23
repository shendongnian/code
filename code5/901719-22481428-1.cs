    public class Session
    {
        private Session() { }
        public static Create()
        {
            DataAccessLayer.Session dal_Session = new DataAccessLayer.Session ();
            var session = new Session();
            dal_Session.GetSession (ref session);
            return session;
        }
    }
