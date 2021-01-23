      public class ColorAndMoreClass: INotifyPropertyChanged
        {
            private Color _c;
            private Color _c2;
            private OtherClass _example;
            
            public ColorAndMoreClass(Color c, Color c2)
            {
                _c= c;
                _c2 = c2;
            }
    
            public OtherClass example
            {
               get { return _example }
               set
               {
                   _example = value;
                   OnPropertyChanged("example");
               }
            }
        
            public Color c
            {
                get { return _c; }
                set
                {
                    _c= value;
                    OnPropertyChanged("c");
                }
            }
    
            public Color c2
            {
                get { return _c2; }
                set
                {
                    _c2 = value;
                    OnPropertyChanged("c2");
                }
            }
        
            public event PropertyChangedEventHandler PropertyChanged;
        
            private void OnPropertyChanged(string info)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(info));
                }
            }
        }
