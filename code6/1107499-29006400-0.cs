    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<User> Users { get; set; }
        public ViewModel()
        {
            Users = new ObservableCollection<User>()
                {
                    new User { Id = 1 }, new User { Id = 2 }
                };
        }
    }
