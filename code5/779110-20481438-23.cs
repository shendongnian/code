    public class ExamplePublisher: PropertyChangedPublisherBase
    {
        private string _id;
        private bool _testBool;
        public string Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public bool TestBool
        {
            get { return _testBool; }
            set
            {
                if (value.Equals(_testBool)) return;
                _testBool = value;
                RaisePropertyChanged("TestBool");
            }
        }
    }
