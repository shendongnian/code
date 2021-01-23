    class ListType{
        public string Key { get; set; }
        public string Value { get; set; }
    }    
    class ViewModel{
         public IEnumerable<SelectListItem> List { get; set; } //This is generated from a list of ListType objects
         public string Selected { get; set; }
    }
