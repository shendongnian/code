    [Serializable()]
    public class SiteDetail
    {
        public string Login{get; set;}
        public string Password{get; set;}
        public string Url {get;set;}
    
        public List<SiteVersion> Versions {get; set;}
    }
