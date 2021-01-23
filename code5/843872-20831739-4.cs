    public class SectionEditViewModel
    {
      public Section Section { set;get;}
      public List<SelectListeItem> Types { set;get;}
      public string SelectedType { set;get;}
      
      public SectionEditViewModel()
      {
        Section=new Section();
        Types=new List<SelectListItem>();        
      }
    }
