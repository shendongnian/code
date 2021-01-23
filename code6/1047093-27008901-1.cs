    public class A<T> : IA<T> 
    {
        public T Item
        {
            get;
            set;
        }
    }
    public class B<T> : IB<T>
    {
        public B(IA<T> ia)
        {
            this.IA = ia;
        }
        public IA<T> IA
        {
            get;
            private set;
        }
    }
