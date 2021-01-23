    namespace WpfApplication1
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private bool selectAll;
            private readonly ObservableCollection<Party> parties = new ObservableCollection<Party>();
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public ObservableCollection<Party> Parties
            {
                get
                {
                    return parties;
                }
            }
    
            public bool SelectAll
            {
                get
                {
                    return selectAll;
                }
                set
                {
                    if (selectAll != value)
                    {
                        selectAll = value;
                        OnPropertyChanged("SelectAll");
                        SelectAllImpl(selectAll);
                    }
                }
            }
    
            private void SelectAllImpl(bool isSelected)
            {
                foreach (Party party in parties)
                {
                    party.IsSelected = isSelected;
                }
            }
        }
    }
