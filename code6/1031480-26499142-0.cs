    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Assignment11
    { 
        class Dog
        {
           public void bark()
           {
               Console.WriteLine("Empty method");
           }
          
           public void bark2(string args);
               Console.WriteLine("fido is Barking");
           }
      class Program
     {
          static void Main(string[] args)
          {
              Dog fido = new Dog();
              fido.bark();
              fido.bark2 ("fido");
              Console.Write("Hit any key to close"); 
              Console.ReadKey(true);
           }
      }
    }
