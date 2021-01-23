    public interface IBar
    {
        void MethodCommonToAllBar();
    }
    public class Bar<T> : Foo, IBar
    {
        public void MethodCommonToAllBar()
        {
            ...
        }
    }
