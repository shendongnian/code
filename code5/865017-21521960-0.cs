        public class ProjectKeys : INotifyPropertyChanged {
            Style styKey = new Style();
            public Style StyKey {
                get {
                    return styKey; 
                } set {
                    styKey = value;
                    NotifyPropertyChanged("StyKey"); 
                } 
            }
            protected void NotifyPropertyChanged(string propertyName) {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            }
            
            public event PropertyChangedEventHandler PropertyChanged; 
        } 
    which contains my all key styles.
