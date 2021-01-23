     public class MainViewModel : INotifyPropertyChanged
        {
            private readonly List<long?> _workorderRepositoryList = new List<long?>() {1, 2, 5, 3, 4};
        public List<long?> AllC
        {
            get { return _workorderRepositoryList; }
            set
            {
                if (value == _workorderRepositoryList)
                    return;
                value = _workorderRepositoryList;
                OnPropertyChanged("AllC");
            }
        }
        private string item;
        public string SelectedC
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged("SelectedC");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand EvaluateStateCommand
        {
            get
            {
                return new RelayCommand(parameter =>
                {
                    var myItem = SelectedC;
                    //your selected item (the value of the combo) is represented by SelectedC
                });
            }
        }
    }
