       public class MainViewModel : ViewModelBase
    {
        ObservableCollection<string> notifications;
        public ObservableCollection<string> Notifications
        {
            get { return notifications; }
            set
            {
                if (notifications != value)
                {
                    notifications = value;
                    base.RaisePropertyChanged(() => this.Notifications);
                }
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(() => this.Notifications.Add("Hello World"));
            }
        }
        public MainViewModel()
        {
            this.Notifications = new ObservableCollection<string>();             
        }
    }
