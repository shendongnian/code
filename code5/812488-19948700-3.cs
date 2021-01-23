    public class MainWindowModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the text
        /// </summary>
        string myProperty = "This is the default text";
    
        /// <summary>
        /// Gets \ sets the text
        /// </summary>
        public string MyProperty
        {
            get { return this.myProperty;  }
            set
            {
                if (this.MyProperty != value)
                {
                    this.myProperty = value;
                    this.OnPropertyChanged("MyProperty");
                }
            }
        }
    
        /// <summary>
        /// fires the property changed event
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        /// <summary>
        /// the property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
