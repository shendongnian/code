        class SomeClass
    {
        public void method1()
        {
            Console.WriteLine("Method1() called");
        }
    }
    class Program
    {
        static void DoStuff(Object obj)
        {
            MethodInfo method = obj.GetType().GetMethod("method1");
            
            if(method != null) //check for null - that is returned if there is no method1
                method.Invoke(obj, new Object[]{});
        }
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();
            DoStuff(someClass);
        }
    }
