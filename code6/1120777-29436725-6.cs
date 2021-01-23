    public class LBItem {
        public IEnumerable<String> Filter(IEnumerable<String> fullList) {
            return fullList.Where( /* filter items here */ );
        }
    }
    public class ViewModel {
        public ObservableCollection<LBItem> LBItems { get; set; }
        private LBItem _selectedItem;
        public LBItem SelectedLBItem { 
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                List2Filtered = (null == _selectedItem) 
                    ? new List<String>() 
                    : _selectedItem.Filter(List2).ToList();
            }
        } 
        public List<String> List2 { get; set; }
        public List<String> List2Filtered { get; set; }
    }
