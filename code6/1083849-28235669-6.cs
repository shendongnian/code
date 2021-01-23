    public class Method
    {
        public static MethodInfo GetInfo<TReturn>(Func<TReturn> method)
        {
            return method.Method;
        }
        public static MethodInfo GetInfo<TP1, TReturn>(Func<TP1, TReturn> method)
        {
            return method.Method;
        }
        public static MethodInfo GetInfo<TP1, TP2, TReturn>(Func<TP1, TP2, TReturn> method)
        {
            return method.Method;
        }
    
        //... Continue with some more Func overloads
        public static MethodInfo GetInfo(Action method)
        {
            return method.Method;
        }
    
        public static MethodInfo GetInfo<TP1>(Action<TP1> method)
        {
            return method.Method;
        }
    
        public static MethodInfo GetInfo<TP1, TP2>(Action<TP1, TP2> method)
        {
            return method.Method;
        }
        //... Continue with some more Action overloads
    }
