    public class SocialSiteViewModel : SocialSite
    {
        public bool IsSelected { get; set; }
    
        public string SocialSitePostID { get; set; }
    }
    public class SocialSitePostViewModel : SocialSitePost
    {
        public List<SocialSiteViewModel> SocialSiteViewModel { get; set; }
    }
