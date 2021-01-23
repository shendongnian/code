    public class DropDownVM
    {
      public int PickedId {get; set;}
      public IEnumerable<SelectListItem> Items {get;set;}
    }
    
    public class FilmEditViewModel
    {
      public string releaseDate { get; set; }
      public DropDownVM films {get;set;}
    }
    
    //Template view
    @model DropDownVM
    
    @Html.DropDownListFor(m => m.PickedId, new SelectList(Items , "Text", "Value"))
    
    //View
    @model FilmEditViewModel
    
    //...form etc.
    @Html.EditorFor(m =>m.films)
