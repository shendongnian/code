    namespace WebApplication1
    {
        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/", Description = "Something about your service")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {
    
            [WebMethod(Description = "What this method does")]
            public string HelloWorld()
            {
                return "Hello World";
            }
        }
    }
