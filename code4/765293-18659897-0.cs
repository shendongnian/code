    public class ViewModel
    {
        private readonly SomeValue _value;
        public ViewModel()
        {
            _value = new SomeValue();
        }
    
        public SomeValue Value { get { return _value; } }
    }
