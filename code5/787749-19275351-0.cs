    class Modifiable<T>
    {
        public T Value { get; st; }
        ...
    }
    class Object1Controller : ...
    {
        public Modifiable<int> MyValue { get; private set; }
    }
