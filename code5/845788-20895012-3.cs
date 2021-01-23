    public class State : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string ID { get; set; }
        public int Description { get; set; }
    
        private bool stateOn { get; set; }
        public bool StateOn
        {
            get 
            {
                return stateOn;
            }
    
            set
            {
                stateOn = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StateOn"));
                }
            }
        }
    }
