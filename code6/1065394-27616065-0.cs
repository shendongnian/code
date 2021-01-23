    [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class Service1 : System.Web.Services.WebService
        {
    
            [WebMethod]
            public string TestMethod(string data ,string fileName)
            {
                return "Hello World";
            }
        }
