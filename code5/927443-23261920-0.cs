    using System.Web.Services;
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        [WebMethod]
        public string CreateUser(string userName, string password)
        {
            //here you can do all the manipulations with your database
            return userName + " - " + password;
        }
    }
