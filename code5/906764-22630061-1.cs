    public class Session : ISession {
        private const string CURRENTUSERKEY = "CurrentUser";
        public static string CurrentUser {
            get { return (string)HttpContext.Current.Session[CURRENTUSERKEY]; }
            set { HttpContext.Current.Session[CURRENTUSERKEY] = value; }
        }
        public static void ClearAllSession() {
            CurrentUser = null; // And the other props
        }
    }
