    public class MainWindowViewModel : NotificationObject
    {
        // your collections
        private ObservableCollection<string> fruits;
        private ObservableCollection<string> vegetables;
        private ObservableCollection<string> others;
        public MainWindowViewModel()
        {
            fruits = new ObservableCollection<string>
                {
                    "Apple", "Banana"
                };
            vegetables = new ObservableCollection<string>
                {
                    "Tomato", "Cabbage"
                };
            others = new ObservableCollection<string>
                {
                    "Pizza", "Steak"
                };
            SelectionChangedCommand = new DelegateCommand<string>(item =>
                {
                    // When user selects item in the listbox change the collection of your comboBox
                    switch (item)
                    {
                        case "Fruits":
                            {
                                Items = fruits;
                                break;
                            }
                        case "Vegetables":
                            {
                                Items = vegetables;
                                break;
                            }
                        case "Others":
                            {
                                Items = others;
                                break;
                            }
                    }
                    // Raise property change to make combobox update
                    RaisePropertyChanged(() => Items);
                });               
        }
        // the collection currently displayed in the comboBox
        public ObservableCollection<string> Items { get; set; }
        // The selected item of the combobox
        public string CurrentItem { get; set; }
        public DelegateCommand<string> SelectionChangedCommand { get; set; }
    }
