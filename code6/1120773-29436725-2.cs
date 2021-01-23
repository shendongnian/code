    public class LBItem {
        public ViewModel Parent { get; set; }
        public IEnumerable<String> SubItems {
            get {
                return Parent.List2.Where( /* filter items here */ );
            }
    }
    public class ViewModel {
        //  
        public ObservableCollection<LBItem> LBItems { get; set; }
        public LBItem SelectedLBItem { get; set; } 
        public List<String> List2 { get; set; }
    }
