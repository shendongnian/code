    public class Article : INotifyPropertyChanged
        {
            private long _Id;
            public long ID
            {
                get { return _Id; }
                set
                {
                    if (_Id != value)
                    {
                        _Id = value;
                        NotifyPropertyChanged("ID");
                    }
                }
            }
    
    
            private string _subject;
            public string Subject
            {
                get
                {
                    return _subject;
                }
                set
                {
                    if (_subject != value)
                    {
                        _subject = value;
                        NotifyPropertyChanged("Subject");
                    }
                }
            }
    
            private string _words;
            public string Words
            {
                get
                {
                    return _words;
                }
                set
                {
                    if (_words != value)
                    {
                        _words = value;
                        NotifyPropertyChanged("Words");
                    }
                }
            }
    
            private DateTime _publishDate;
            public DateTime PublishDate
            {
                get
                { return _publishDate; }
                set
                {
                    if (_publishDate != value)
                    {
                        _publishDate = value;
                        NotifyPropertyChanged("PublishDate");
                    }
                }
            }
    
            private ObservableCollection<string> _imagePathList = new ObservableCollection<string>();
            public ObservableCollection<string> ImagePathList
            {
                get { return this._imagePathList; }
                set
                {
                    if (this._imagePathList != value)
                    {
                        this._imagePathList = value;
                        // I'm going to assume you have the NotifyPropertyChanged
                        // method defined on the view-model
                        this.NotifyPropertyChanged();
                    }
                }
            }
    
            BitmapImage _image;
            public BitmapImage BitImage
            {
                get
                {
                    return _image;
                }
                set
                {
                    if (ImagePathList.Any())
                    {
                        value = new BitmapImage(new Uri(ImagePathList.FirstOrDefault(), UriKind.RelativeOrAbsolute));
                        _image = value;
                    }
                }
            }
    
            private Uri _firstImage;
            public Uri FirstImage
            {
                get
                {
                    return _firstImage;
                }
                set
                {
                    if (_firstImage != value)
                    {
                        _firstImage = value;
                        NotifyPropertyChanged("FirstImage");
                    }
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
