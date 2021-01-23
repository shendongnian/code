    public class PhotoItemViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<PhotoItem> photoList;
            public ObservableCollection<PhotoItem> PhotoList
            {
                get
                {
                    return photoList;
                }
                set
                {
                    photoList = value;
                    NotifyPropertyChanged();
                }
            }
     
            public void LoadData()
            {
                PhotoList = new ObservableCollection<PhotoItem>(PhotoItem.GetPhotos());
            }
     
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
