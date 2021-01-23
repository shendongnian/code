    static void Main(string[] args)
        {
            var DLL = Assembly.LoadFile(@"C:\visual studio 2012\Projects\ConsoleApplication1\ConsoleApplication1\DLL.dll");
            
            var class1Type = DLL.GetType("DLL.Class1");
           
            //Now you can use reflection or dynamic to call the method. I will show you the dynamic way
            
            dynamic c = Activator.CreateInstance(class1Type);
            c.Output(@"Hello");
            
            Console.ReadLine();
         }
