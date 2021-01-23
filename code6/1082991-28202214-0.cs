    public class HubDataContext : INotifyPropertyChanged
    {
        private string firstNameTextBox;
        public string FirstNameBoxText
        {
            get { return firstNameTextBox; }
            set
            {
                firstNameTextBox = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FirstNameBoxText"));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
