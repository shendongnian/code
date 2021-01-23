    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SomeModel> models;
        public ObservableCollection<SomeModel> Models
        {
            get { return models; }
            set
            {
                if (Equals(value, models)) return;
                models = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            Models = new ObservableCollection<SomeModel>();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
