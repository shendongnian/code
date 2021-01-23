     static void Main(string[] args)
     {
          var factory = new MyFactory();
          var obj = factory.GetObject<MyClass>();
    
          obj.Method1();
          Console.ReadKey();
     }
