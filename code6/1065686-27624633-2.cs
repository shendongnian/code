    public class RetrieveWidgets : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static RetrieveWidgetsDAL[] GetWidgets()
        {
            //...
        }
    }
