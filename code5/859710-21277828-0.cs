    public class A<T>
    {
        public static string DoWork() { return "working" + typeof(T).ToString(); }
    }
        
    public class B : A<B> { }
