    using System;
    
    namespace Inheritance
    {
        class Program
        {
            public class Person
            {
                virtual public void Save()
                {
                    Console.WriteLine("Person Save");
                }
            }
            public class Emp : Person
            {
                override public void Save() {
                    Console.WriteLine("Emp Save");
                }
            }
            static void Main(string[] args)
            {
                Person p = new Emp();
                p.Save();
            }
        }
    }
