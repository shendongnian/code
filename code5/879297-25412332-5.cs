    public class A<T> // an argument to the generic method
    {
    }
    public class B<S>
    {
        public virtual R Fun<T>(A<T> arg) where S : T // illegal in C#/CLR
        {
            ...
        }
    }
    public class C<S> : B<S>
    {
        public override R Fun<T>(A<T> arg)
        {
        }
    }
