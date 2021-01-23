    public class MainWindowViewModel : NotificationObject
    {
        public MainWindowViewModel()
        {
            Model = new MyModel();
            ToggleCommand = new DelegateCommand(() =>
                {
                    Model.IsChecked = !Model.IsChecked;
                    Model.IsEnabled = !Model.IsEnabled;
                });
        }
        public DelegateCommand ToggleCommand { get; set; }
        public MyModel Model { get; set; }
    }
