    public abstract class State<T> where T : Unit
    {
        protected State(T unit)
        {
            this.Unit = unit;
        }
        
        protected T Unit { get; private set; }
        public abstract void Handle();
    }
