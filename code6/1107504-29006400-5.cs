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
                    new User { Sam = "1", Active = "True", FName ="Test First Name 1", LName ="Test Last Name 1"}, 
                    new User { Sam = "2", Active = "True", FName ="Test First Name 2", LName ="Test Last Name 2"}, 
                };
        }
    }
