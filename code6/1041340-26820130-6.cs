    public class MyViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MyViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private ICommand _doSomething;
        public ICommand DoSomething
        {
            get
            {
                return _doSomething ??
                    new RelayCommand(() =>
                        {
                            _navigationService.Navigate(typeof(Page2));
                        });
            }
        }}
