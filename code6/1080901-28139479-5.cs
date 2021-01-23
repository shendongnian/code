    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            People = new ObservableCollection<Dictionary<string, string>> {
                new Dictionary<string, string>() {{"Name", "Abe"}, {"Age", "50"}, {"Gender", "Male"}},
                new Dictionary<string, string>() {{"Name", "Shelly"}, {"Age", "20"}, {"Gender", "Female"}}
            };
        }
        public ObservableCollection<Dictionary<string, string>> People { get; private set; } 
    }
