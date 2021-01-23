    [NotifyPropertyChanged]
    public class OsModel : INotifyPropertyChanged
    {
        public int P1 { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
