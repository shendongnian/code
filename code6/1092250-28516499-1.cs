        class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                ButtonContents = new ObservableCollection<string>();
                ButtonContents.Add("3");
                ButtonContents.Add("4");
            }
            public ObservableCollection<string> ButtonContents { get; set; }
        }
