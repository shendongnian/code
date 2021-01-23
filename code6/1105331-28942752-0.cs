    public class NugetPlatformModel
      {
        public bool IsHavingLicense { get; set; }
        public List<PlatformProducts> PlatformProduct = new List<PlatformProducts>();
        public NugetPlatformModel(IPlatformProductProvider provider)
        {
          var xmldoc = new XmlDocument();
          //System.Web.HttpContext.Current.Server.MapPath(@"~\Content\PlatformProducts.xml")
          xmldoc.Load(provider.Filepath);
        }
    
        public interface IPlatformProductProvider
        {
          string Filepath { get; }
        }
    
        public class PlatformProductProvider: IPlatformProductProvider
        {
          string _filepath;
          public string Filepath
          {
            get { return _filepath; }
            set { _filepath = value;}
          }
    
          public PlatformProductProvider(string path)
          {
            _filepath = path;
          }
        }
    
      }
