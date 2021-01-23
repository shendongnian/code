    public interface IFooable<T>
    {
        IEnumerable<T> Foo();
    }
    public sealed class Fooable<T> : IFooable<T>
    {
        public List<T> Foo()
        {
            //...
        }
        IEnumerable<T> IFooable<T>.Foo()
        {
            return Foo();
        }
    }
