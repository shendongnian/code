    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script
    [ScriptService]
    public class Service: System.Web.Services.WebService 
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]    
        public List<string> getlastimages()
        {
          DBservices DBS = new DBservices();
          List<string> ImageUrls = new List<string>();
          try
          {
           DBS.getLastImages();
           ImageUrls = DBS.ImgUrlList;
          }
          catch(Exception ex)
          {
            throw ex;
          }
          return ImageUrls;
        }
    }
