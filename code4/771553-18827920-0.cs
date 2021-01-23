    Assembly asm = Assembly.Load("Test");
    Type t = asm.GetType("test.myclass");
    dynamic obj = Activator.CreateInstance(t);
    Console.WriteLine("output {0}", obj.Foo(10, 70));
    
