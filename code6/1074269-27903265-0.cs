    class MainViewModel
    {
        private MyMessage _messageProperty;
        public MyMessage MessageProperty 
        {
                get { return _messageProperty; }
                set { _messageProperty = value; }
        }
        public MainViewModel()
        {
            _messageProperty = new MyMessage();
            _messageProperty.TestMessage="Hai";
        }
