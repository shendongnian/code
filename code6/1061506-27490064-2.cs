    public class ViewModel{
    
     public IEnumerable<ABC> xyz { get; set; }
        public List<SelectListItem> device { get; set; }
        public List<SelectListItem> type { get; set; }        
        public SelectListItem selectedItem { set; get; }
    //these are all the properties that ABC has
    
        public int a { get; set; }
        public string Name{ get; set; }
    }
