    public class SearchViewModel {
        public string param1 {get;set;}
        public string search {get;set;}
    }
    
    [HttpPost] // <-- were you missing this before?
    public ActionResult Search(SearchViewModel model)  
    {
       // access with model.param1
    }
    
    @model SearchViewModel
    
    @using (Html.BeginForm("search", "home", FormMethod.POST ))
    {
         @Html.HiddenFor(x=>x.param1)
         @Html.TextBoxFor(x=>x.search)
         <button type="submit">Search </button>
    }
