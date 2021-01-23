    public class A : INotifyPropertyChanged
        {   
            private IList<int> _lists;
            IList<int> List { 
                get {
                   return _lists;
                }; 
                set {
                   _lists = value;
                   OnPropertyChanged("List");
                }
              }
     public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }  
