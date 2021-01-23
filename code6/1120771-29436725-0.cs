    public class LBItem {
        public ObservableCollection<String> SubItems { get; set; }
    }
    public class ViewModel {
        public ObservableCollection<LBItem> LBItems { get; set; }
        public LBItem SelectedLBItem { get; set; } 
    }
