    public class LocationToShow : ARItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
               handler(this, new PropertyChangedEventArgs(name));
            }
         }
         
         private bool isChecked;
         public bool IsChecked 
         { 
             get { return isChecked; }
             set
             {
                if (isChecked != value)
                {
                   isChecked = value;
                   OnPropertyChanged("IsChecked");
                }
             }
         }
    }
