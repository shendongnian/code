    public class CreatePostVM
    {
      public string Name { set;get;}
      public List<SelectListItem> Pages { set;get;}
      public int SelectedPage { set;get;}
      public CreatePostVM()
      {
        Pages =new List<SelectListItem>();
      }
    }
