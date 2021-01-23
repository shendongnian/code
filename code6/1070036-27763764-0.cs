    public class M<T> 
    {
        public Do<T>() 
        {
            DoMore<T>();
        }
    }
    public class A : M<A> {...}
    public class B : M<B> {...}
    public class C : M<C> {...}
