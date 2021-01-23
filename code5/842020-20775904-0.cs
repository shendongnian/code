    public class SectionViewModel
    {
        public SectionViewModel(){}
        public SectionViewModel(Section section)
        {
           //set the property values now.
           Title=section.Title;
           HasLogo=(section.Logo!=null && (section.Logo.ID>0)) 
        }
       
        public Int16 SectionID { get; set; }    
        public bool HasLogo { get; set; } 
        public string Type { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
    }
