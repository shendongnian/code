    public class CreateCarVM
    {
      [Required]
      public string Title { set;get;}
      public List<SelectListItem> Categories { set;get;}
      [Required]
      public int SelectedCategory { set;get;}
      public CreateCarVM()
      {
        Categories =new List<SelectListItem>();
      }
    }
