    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService {
    
        public WebService () {
    
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
    
        [WebMethod]
        public List<string>GetNewMessage() {
            List<string> newMessages= ChatClass.GetNewMessages()
            return newMessages;
        }
        
    }
  
