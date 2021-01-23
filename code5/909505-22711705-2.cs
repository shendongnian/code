    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [System.Web.Script.Services.ScriptService] // <- ** MAKE SURE THIS IS UNCOMMENTED!
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public int GetQuickVD(int key)
        {
            return key;
        }
    }
