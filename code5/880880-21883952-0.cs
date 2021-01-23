    public static class CookieHelper
    {
        public static Guid GetCurrentUserId(IIdentity identity)
        {
            Guid result;
            var userData = ((FormsIdentity)identity).Ticket.UserData;
            result = new Guid(userData.Split('|')[0]);
            return result;
        }
        public static int GetCurrentAccountTypeId(IIdentity identity)
        {
            int result;
            var userData = ((FormsIdentity)identity).Ticket.UserData;
            result = Convert.ToInt16((userData.Split('|')[1]));
            return result;
        }
    }
