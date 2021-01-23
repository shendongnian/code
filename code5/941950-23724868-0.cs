    interface IAbstract
    {
        string A { get; }
        object B { get; }
    }
    interface IAbstract<T> : IAbstract
    {
        T B { get; }
    }
    sealed class RealThing<T> : IAbstract<T>
    {
        public string A { get; private set; }
        public T B { get; private set; }
        object IAbstract.B
        {
            get { return B; }
        }
    }
