    public class SomeClass<T>
    {
        public Type InstanceType { get { return typeof(T); } }
        public void SomeMethod<T> () { }
    }
