        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            ...
        
            public event PropertyChangedEventHandler PropertyChanged;
            
            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
            
            private Int32 _pageWidth;
            public Int32 PageWidth
            {
                get
                {
                    return _pageWidth;
                }
                set
                { 
                    if ( _pageWidth != value )
                    {
                         _pageWidth = value;
                         OnPropertyChanged("PageWidth");
                    }
                }
             }
        
             ...
