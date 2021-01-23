    public class NumberCalculatedEventArgts : EventArgs
    {
        public NumberCalculatedEventArgts(int value)
        {
            Value = value;
        }
 
        public int Value { get; private set; }
    }
