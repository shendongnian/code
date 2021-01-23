    public class ViewModel : INotifyPropertyChanged
        {
            public ICollectionView Images { get; private set; }
            public ViewModel()
            {
            }
            public void LoadImages()
            {
                var folder = @"C:\Users\lrved_000\Pictures";
                var photos = System.IO.Directory.EnumerateFiles(folder, "*.jpg",SearchOption.AllDirectories);
                Images = CollectionViewSource.GetDefaultView(photos);
                RaisePropertyChanged("Images");
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
