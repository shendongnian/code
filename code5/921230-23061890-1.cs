    class PhotoItemViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<PhoneApp1.Model.PhotoItem> _photoList;
            public ObservableCollection<PhoneApp1.Model.PhotoItem> PhotoList
            {
                get
                {
                    return _photoList;
                }
    
                set
                {
                    _photoList = value;
                    OnPropertyChanged();
                }
            
            
            }
           
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public void LoadData()
            {
                _photoList = new ObservableCollection<Model.PhotoItem>(Model.PhotoItem.getPhotos());
            
            }
        }
