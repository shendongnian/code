    namespace WebApplicationSO2
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class WebService1 : System.Web.Services.WebService
        {
            [WebMethod]
            public string HelloWorld() {
                Assembly a = Assembly.GetExecutingAssembly();
                var attribute = (GuidAttribute)a.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                var guidFromDll = Logger.AssemblyGuid;
                return "My Guid: " + attribute.Value + " Guid from Dll: " + guidFromDll; // returns 'My Guid: df21ba1d-f3a6-420c-8882-92f51cc31ae1 Guid from Dll: df21ba1d-f3a6-420c-8882-92f51cc31ae1'
                
            }
         }
    }
