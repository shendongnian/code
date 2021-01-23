    class TestClass
    {
        private string _someProp { get; set; }
        public string SomeProp { 
            get
            {
                if(string.IsNullOrEmpty(_someProp)
                {
                    _someProp = "";
                }
                return _someProp;
            }
            set
            {
                _someProp = value;
            }
        }
        private string _someOtherProp { get; set; }
        public string SomeOtherProp { 
            get
            {
                if(string.IsNullOrEmpty(_someOtherProp)
                {
                    _someOtherProp = "";
                }
                return _someOtherProp;
            }
            set
            {
                _someOtherProp = value;
            }
        }
    }
