    public class YourClass
    {
        private int _resetPosition;
    
        public void Mark()
        {
            _resetPosition = Position;
        }
    
        public void Reset()
        {
            Position = _resetPosition;
        }
    }
