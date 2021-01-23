    // Create a class that implements INotifyPropertyChanged.
    public class DefaultViewModel: INotifyPropertyChanged
    {
        private String _text;
    
        // Declare the PropertyChanged event.
        public event PropertyChangedEventHandler PropertyChanged;
    
        // Create the property that will be the source of the binding.
        public String Text
        {
            get { return _text; }
            set
            {
                _text = value;
                // Call NotifyPropertyChanged when the source property 
                // is updated.
                NotifyPropertyChanged("Text");
            }
        }
    
        // NotifyPropertyChanged will fire the PropertyChanged event, 
        // passing the source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, 
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
