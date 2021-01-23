    using System;
    
    namespace ConsoleApplication2
    {
        public class Class1
        {
            public string MySTR;
        }
    
    
        class Program
        {     
    
    
                private static void func1(Class1 c )
                 {
                  //c = new Class1();
                  c.MySTR = "B";
                 }
    
                private static void func2(Class1 c )
                {
                  c.MySTR = "C";
                }
    
                static void Main(string[] args) 
                {       
                  Class1  c = new Class1();
                  c.MySTR = "A";
                  func1(c);
                  Console.WriteLine(c.MySTR);
                  //func2(ref c);Error
                  //Console.WriteLine(c.MySTR);
                  Console.ReadKey();
                }
        }
    }
