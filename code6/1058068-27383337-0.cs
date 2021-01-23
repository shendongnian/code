    public class ViewModel
    {
        private static ViewModel instance = new ViewModel();
        public static ViewModel Instance
        {
            get
            {
                return instance;
            }
        }
        public ObservableCollection<string> vlan { get; set; }
    }
