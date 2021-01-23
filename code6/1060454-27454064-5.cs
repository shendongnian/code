    public class ValueChangedEvent
    {
        public int Value
        {
            get { return _value; }
        }
        private readonly int _value;
        public ValueChangedEvent(int value)
        {
            _value = value;
        }
    }
