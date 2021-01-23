    using System.IO;
    using System;
    using System.Collections.Generic;
    
    
    class Program
    {
        static List<Type> list = new List<Type>();
        
        static void Main()
        {
            
            list.Add(typeof(A));
            C c = new C();
            D d = new D();
            
            Check(c);
            Check(d);
            
        }
        
        static void Check(Object toBeChecked){
            
            foreach (Type t in list)
            {
                if(t.IsAssignableFrom(toBeChecked.GetType())){
                    System.Console.WriteLine("Yes it is type of");
                    return;
                }
                System.Console.WriteLine("No it is not type of");
            }
        }
    }
    
    class A{
        
    }
    
    class C : A{
        
    }
    
    class D{
        
    }
