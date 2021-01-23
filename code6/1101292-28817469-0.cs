    private static readonly string TRUETEXT = "This is the text to show when true";
        private static readonly string FALSETEXT = "This is the text to show when false";
        private bool _myBooleanProperty;
        public bool MyBooleanProperty
        {
            get { return _myBooleanProperty; }
            set
            {
                if (_myBooleanProperty != value)
                {
                    _myBooleanProperty = value;
                    OnPropertyChanged("MyBooleanProperty");
                    OnPropertyChanged("ResultText");
                }
            }
        }
        public string ResultText
        {
            get
            {
                return MyBooleanProperty ? TRUETEXT : FALSETEXT;
            }
        }
