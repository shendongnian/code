    public class ViewModel
    {
        private static ViewModel instance = new ViewModel();
        private ViewModel()
        {
        }
        public static ViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewModel();
                return instance;
            }
        }
        
        public ObservableCollection<string> vlan { get; set; }
    }
