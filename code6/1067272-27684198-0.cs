     public class PageContext : Page
    { 
        public virtual string PageName
        {
            get
            {
                return null;
            } 
        }
        public string Permission
        {
            get
            {
                switch (PageName)
                {
                    case "Page1":
                        return "Read";
                    case "Page2":
                        return "Write";
                    default:
                        return "None";
                }
            }
        }
    }
