        public class cList : DependencyObject, INotifyPropertyChanged
        {    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public string myText
            {
                get 
                { 
                     return (string)GetValue(myTextProperty); 
                }
                set 
                { 
                    SetValue(myTextProperty, value);
                    NotifyPropertyChanged("myText"); 
                }
            }
            .....
            .....
        }
