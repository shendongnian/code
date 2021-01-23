    [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [ScriptService]
        [ToolboxItem(false)]
        public class Testser : System.Web.Services.WebService
        {
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public String GetData(String FileName)
            {
                         string msg = FileName;
                return msg;
            }
        }
