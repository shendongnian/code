    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMethodCalls = 5;
            string[] charList = new string[] { "A", "B", "C" };
            Console.WriteLine("Static calls --------------");
            for(int b = 0; b < numberOfMethodCalls; b++)
            {
                typeof(Program).GetMethod("Method" + (b%3).ToString()).Invoke(null, new object[] { b }); // call static method
            }
            Console.WriteLine("Calls for object ----------");
            Program p = new Program();
            for(int b = 0; b < numberOfMethodCalls; b++)
            {
                CallMethod(p.GetType().ToString(), "Method" + charList[b%3], b);
            }
            Console.ReadLine();
        }
        public static void CallMethod(string typeName, string methodName, int param)
        {
            Type type = Type.GetType(typeName);
            object instance = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodName);
            methodInfo.Invoke(instance, new object[] { param });
        }
        public static void Method0(int num) { Console.WriteLine("1: STATIC b=" + num.ToString()); }
        public static void Method1(int num) { Console.WriteLine("2: STATIC b=" + num.ToString()); }
        public static void Method2(int num) { Console.WriteLine("3: STATIC b=" + num.ToString()); }
        public void MethodA(int num) { Console.WriteLine("1: b=" + num.ToString()); }
        public void MethodB(int num) { Console.WriteLine("2: b=" + num.ToString()); }
        public void MethodC(int num) { Console.WriteLine("3: b=" + num.ToString()); }
    }
