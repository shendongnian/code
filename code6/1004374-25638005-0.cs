    public class SiteMapSection
    {
       public string sectionUrl { get; set; }
       public List<SiteMapSubSection> subSection { get; set; }
       public SiteMapSection()
       {
            subSection    =new List<SiteMapSubSection>();
       }
     }
