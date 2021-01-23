    public class AdvanceSearchViewModel: INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        .....
        Your Properties Here
        .....
        
        private bool _isProcessStart
        public bool IsProcessStart
        {
           get { return _isProcessStart; }
           set { 
                 _isProcessStart = value; 
                 OnPropertyChanged("IsProcessStart"); }
               }
    }
