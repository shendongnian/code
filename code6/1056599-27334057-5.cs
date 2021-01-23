    using System; 
    using System.Reflection;
    
    namespace MyProgram 
    { 
        class MyProgram 
        { 
              static void Main() 
              { 
                  Assembly assembly = Assembly.LoadFrom("mytest.dll");
                  object mc = assembly.CreateInstance("MyTest.MyClass");
                  Type t = mc.GetType(); 
                  BindingFlags bf = BindingFlags.Instance |  BindingFlags.NonPublic;
                  MethodInfo mi = t.GetMethod("MyMethod", bf); 
                  mi.Invoke(mc, null); 
                  Console.ReadKey(); 
             } 
        } 
    }  
