    public class MyClass : IMyInterface
    {
        private string _test;
        public string Test
        {
            get { return _test; }
            set
            {
                _test = value;
                RaisePropertyChanged("Test");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            // Null means no subscribers to the event
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
