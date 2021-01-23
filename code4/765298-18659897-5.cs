    public class ViewModel
    {
        private SomeValue _value;
    
        public SomeValue Value { get { return _value ?? (_value = new SomeValue()); } } 
    }
