    using System;
    public class MyClass
    {
       public static implicit operator Func<MyClass>(MyClass obj)
       {
         return () => { Console.WriteLine("this is another cheat"); return new MyClass(); };
       }
    }
    public class Program
    {
       static void Main(string[] args)
       {
          MyClass x = new MyClass();
          WriteConditional(x);
          Console.ReadLine();
       }
       static void WriteConditional(Func<MyClass> retriever) {  }
    }
