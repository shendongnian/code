    public interface IShallowClonable<T>
    {
        T ShallowClone();
    }
    public MyClass : IShallowClonable<MyClass>
    {
        //TODO: define class members.
        public T ShallowClone()
        {
            return (T)MemberwiseClone(this);
        }
    }
