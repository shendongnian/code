    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
           MyClass one = new MyClass();
            MyClass two = new MyClass();
            MyClass three = new MyClass();
            
            one.Load(10);
            two.Load(50);
            three.Load(100);
            
            System.Console.WriteLine("One.Count  " + one.Params.Count);
            System.Console.WriteLine("Two.Count " +two.Params.Count);
            System.Console.WriteLine("Three.Count  "+ three.Params.Count);
        }
    }
    
    public class MyClass
     {
         public List<int> Params = new List<int>();
    
          public void Load(int data)
            {
                Params.Add(data);
            }
    }
