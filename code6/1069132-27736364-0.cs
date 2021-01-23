    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo miOpen = typeof(Program).GetMethod("Method", BindingFlags.Static | BindingFlags.NonPublic),
                miClosed = miOpen.MakeGenericMethod(typeof(int));
            Type type;
            object[] invokeArgs = { 17, null };
            int[] rgi = (int[])miClosed.Invoke(null, invokeArgs);
            type = (Type)invokeArgs[1];
        }
        static T[] Method<T>(T t, out Type type)
        {
            type = GetMethodType();
            return new[] { t };
        }
        private static Type GetMethodType()
        {
            StackFrame frame = new StackFrame(1, false);
            MethodBase mi = frame.GetMethod();
            return mi.GetGenericArguments()[0];
        }
    }
