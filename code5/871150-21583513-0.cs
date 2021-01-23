    public abstract class Operation<T> : IOperation
    {
        public new abstract T Work();
        void IOperation.Work()
        {
            Work();
        }
    }
