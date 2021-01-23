    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
        namespace DemoApp
        {
            class Program
            {
                static void Main(string[] args)
                {
                    List<DemoClass> list = new List<DemoClass>();
        
                    list.Add(new DemoClass() { Key = "A1" });
                    list.Add(new DemoClass() { Key = "A2" });
                    list.Add(new DemoClass() { Key = "A3" });
        
                    // Print
                    foreach (var it in list) { Console.WriteLine(it.Key); }
                    Console.WriteLine();
        
                    // set one key to null
                    list[1].Key = null;
        
                    list.RemoveAll(Item => Item.IsToDelete());
                    
                    // Print
                    foreach (var it in list) { Console.WriteLine(it.Key); }
                    Console.WriteLine("As you can see, A2 is missing");
        
                    Console.ReadLine();
                }
            }
        
            class DemoClass
            {
                public string Key
                {
                    get;
                    set;
                }
        
                public object SomeValue
                {
                    get;
                    set;
                }
                public bool IsToDelete()
                {
                    if(Key == null || SomeValue == null)
                    {
                         return true;
                    }
                    return false;
                }
            }
        }
