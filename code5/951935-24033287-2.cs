    public class MenuModelView
    {
       // Presentation tier stuff
       public string PageTitle { get; set; }
       public string MetaTagsForSEO { get; set; }
       public bool IsThisARegisteredUserSoSkipTheAdverts { get; set; }
       // Your EF / Domain Model
       public Menu Menu { get; set; }
    }
