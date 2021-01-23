    public class CustomBasePage : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static bool ValidateUser(...)
        {
            bool isValid = false;
            ...
            return isValid;
        }
    }
