    public class YourClass : INotifyPropertyChanged
    {
        // Your private variable
        private Mode mode;
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;
        public YourClass()
        {
        }
        public Mode NavigatorMode 
        {
           get { return mode; }
           set
           {
              mode = value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged(mode);
           }
        }
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(Mode modeParam)
        {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null)
           {
              handler(this, new PropertyChangedEventArgs(modeParam));
           }
        }
     }
