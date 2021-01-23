    public class ExtendWebSecurity
    {
        public static boolean Login(
            this WebSecurity ws,
            string username,
            string password,
            boolean persist,
            int companyId)
        {
            // Add your logic
            return ws.Login(username, password, persistCookie: persist);
        }
    }
