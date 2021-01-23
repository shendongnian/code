    interface IMathOps
    {
        Add(IMathOps other);
        object Value { get; }
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
