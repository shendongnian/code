    public class Test<T>
    {
        public static T F(T arg)
        {
            return arg;
        }
        
        public Func<T, T> FuncF = F;
    }
