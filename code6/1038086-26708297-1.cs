     public class BaseClass
    {
        private string  _property = "value";
        public string property1
        { 
            get
            {
                return _property;
            }
            protected set
            {
                _property = value;
            }
        }
        public string property2 { get; set; }
        public string property3 { get; set; }
    }
