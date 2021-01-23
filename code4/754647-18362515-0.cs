    class Program
    {
        static void Main(string[] args)
        {
            var DLL = Assembly.LoadFile(@"C:\visual studio 2012\Projects\ConsoleApplication1\ConsoleApplication1\DLL.dll");
            var theType = DLL.GetType("DLL.Class1");
            var c = Activator.CreateInstance(theType);
            var method = theType.GetMethod("Output");
            method.Invoke(c, new object[]{@"Hello"});
            Console.ReadLine();
        }
    }
