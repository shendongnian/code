     public class Thumbnail : INotifyPropertyChanged
            {
                private BitmapImage tmpbmp;
                public BitmapImage testimage { get { return tmpbmp; } set { tmpbmp = value; OnPropertyChanged("testimage"); } }
                public Thumbnail()
                {
                    tmpbmp = new BitmapImage(new Uri("http://www.diseno-art.com/news_content/wp-content/uploads/2012/09/2013-Jaguar-F-Type-1.jpg"));
                }
    
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected virtual void OnPropertyChanged(string propertyName)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
