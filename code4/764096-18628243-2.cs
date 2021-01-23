    public class ImgLink
    {
        public string img;
    }
    
    
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
         [System.Web.Script.Services.ScriptService]
    public class ImgService : WebService
    {
        List<ImgLink> Imgs = new List<ImgLink>{
            new ImgLink{img="/kazvan-1.jpg"},
            new ImgLink{img="/kazvan-2.jpg"},
            new ImgLink{img="/wojno-3.jpg"}
        };
        [WebMethod]
        public List<ImgLink> GetAllImgs()
        {
            return Imgs;
        }
    }
