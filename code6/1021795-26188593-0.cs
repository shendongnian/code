    public class SomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> listOfAwesomeStrings;
        public ObservableCollection<string> ListOfAwesomeStrings
        {
            get { return listOfAwesomeStrings; }
            set
            {
                if (value.Equals(listOfAwesomeStrings))
                {
                    return;
                }
                listOfAwesomeStrings= value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
    
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
