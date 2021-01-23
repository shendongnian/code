    using System;
    using System.Reflection;
    namespace Example
    {
      class Program
      {
        static void Main(string[] args)
        {
            VM_MyClass model = new VM_MyClass();
            model["Name"] = "My name";
            model["DOB"] = DateTime.Today;
            Console.WriteLine(model.Name);
            Console.WriteLine(model.DOB);
            //OR
            Console.WriteLine(model["Name"]);
            Console.WriteLine(model["DOB"]);
            Console.ReadLine();
        }
      }
    }
