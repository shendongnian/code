    interface IMathOps
    {
        object Value { get; }
        void Add(IMathOps other);
        // other methods for substraction etc.
    }
    
    class IntWrapper : IMathOps
    {
        public int value;
    
        public void Add(IMathOps other)
        {
            if(other is IntWrapper)
            {
                this.value += (int)other.Value;
            }
        }
    
        public object Value { get { return this.value; } }
    }
    // class FloatWrapper : IMathOps ...
