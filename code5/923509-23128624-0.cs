    using System;
    using System.Reflection;
    class Program
    {
        class MyAttr : Attribute { }
    
        abstract class Base { };
    
        class Derived : Base
        {
            [MyAttr]
            public void foo() { Console.WriteLine("foo"); }
            public void bar() { Console.WriteLine("bar"); }
        }
    
        static void Main()
        {
            Base someInstance = new Derived();
    
            foreach (var m in someInstance.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (m.GetCustomAttribute(typeof(MyAttr)) != null)
                {
                    m.Invoke(someInstance, null); // prints "foo"
                }
            }
    
            Console.ReadLine();
        }
    }
