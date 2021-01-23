    public interface IClonable<T>
    {
        T Clone();
    }
    public MyClass : IClonable<MyClass>
    {
        //TODO: define class members.
        public T Clone()
        {
            return (T)MemberwiseClone(this);
        }
    }
