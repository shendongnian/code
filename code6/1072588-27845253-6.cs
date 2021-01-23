    [Serializable()]
    public class SiteVersion : SiteDetail // inherited from SiteDetail to store backup
    {
        public int Version{get; set;}
        public string Culture{get; set;}
        public DateTime CreatedOn{get; set;}
    }
