    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RunFunction("Function1"));
        }
        static object RunFunction(string functionName)
        {
            MethodInfo[] methodInfos = typeof(CallableFunctions).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var callableFunctions = new CallableFunctions();
            return methodInfos.First(mi => mi.Name == functionName).Invoke(callableFunctions, null);
        }
    }
    class CallableFunctions
    {
        public string Function1()
        {
            return "Abc";
        }
        public string Function2()
        {
            return "Def";
        }
    }
