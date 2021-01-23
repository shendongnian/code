    public class ViewModel
    {
        public string Name {get;set;}
        public string SelectedLocation {get;set;}
    
        public IEnumerable<SelectListItem> Locations {get;set;}
    }
