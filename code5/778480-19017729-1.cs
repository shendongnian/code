    class Program
    {
        static void Main()
        {
            InvokeOperationMethod(
                typeof(Program).GetMethod("MyOperation"),
                new Program(), o => o.ToString() == "42");
        }
        public bool MyOperation(Func<string, bool> op)
        {
            return op("43");
        }
        public static bool InvokeOperationMethod(
            MethodInfo info, object obj, Func<object, bool> opAsObject)
        {
            return (bool)info.Invoke(obj, new object[] { opAsObject });
        }
    }
