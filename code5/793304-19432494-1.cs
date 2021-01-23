    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Names> _namesList;
        private Names _selectedName;
        public ViewModel()
        {
            NamesList = new ObservableCollection<Names>(new List<Names>
                {
                    new Names() {Id = 1, Name = "John"},
                    new Names() {Id = 1, Name = "Mary"}
                });
        }
        public ObservableCollection<Names> NamesList
        {
            get { return _namesList; }
            set
            {
                _namesList = value;
                OnPropertyChanged();
            }
        }
        public Names SelectedName
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
