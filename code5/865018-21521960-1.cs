        public class VMBase : INotifyPropertyChanged {
            public VMBase() { } 
            ProjectKeys styKey = App.AllStyleKeys; 
            public ProjectKeys VMStyKey {
                get { 
                    return styKey; 
                } set { 
                    styKey = value; 
                    NotifyPropertyChanged("VMStyKey"); 
                } 
            }
            protected void NotifyPropertyChanged(string propertyName) {
                if (PropertyChanged != null) 
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public event PropertyChangedEventHandler PropertyChanged; 
        }
