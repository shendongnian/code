    // replace with whatever, like extend Galasoft's ViewModelBase 
    public class YourViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // Remove if no R#
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class YourViewModel : YourViewModelBase
    {
        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (value.Equals(dateTime)) return;
                dateTime = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectedDateChangedCommand { get; set; }
        public YourViewModel()
        {
            SelectedDateChangedCommand = new RelayCommand<SelectionChangedEventArgs>(OnSelectedDateChanged);
        }
        private void OnSelectedDateChanged(SelectionChangedEventArgs e)
        {
            if (e != null)
                e.Handled = true; // dirty hack
            // do stuff here
        }
    }
