    public sealed class WriteLine
    {
        private readonly StringBuilder _accumulator = new StringBuilder();
    
        public WriteLine OutAnd(string text)
        {
            _accumulator.Append(text);
            return this;
        }
    
        public void ToDebug()
        {
            Debug.WriteLine(_accumulator.ToString());
        }
    }
