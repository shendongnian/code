    namespace ClientName.Version.Services
    {
       [WebService(Namespace = "http://tempuri.org/")]
       [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
       [System.ComponentModel.ToolboxItem(false)]
       [System.Web.Script.Services.ScriptService]
       public class ClassName : System.Web.Service.WebService
       {
          [WebMethod(EnableSession = true)]
          public List<ReturnData> WebMethod(string param1)
          {
                .
                .
                .
          }
        }
    }
