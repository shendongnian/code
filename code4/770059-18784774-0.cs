    using System;
    
    namespace ConsoleApplication16
    {
      class SO
      {
        public static void Main()
        {
          var manager = new LateSetter<int>();
          
          int i = 1;
    
          manager.SaveSetter(newValue => i = newValue);
    
          Console.WriteLine(i); // prints 1
    
          i = 2;
          Console.WriteLine(i); // prints 2
    
          manager.SetValue(3); // change value to 3
          Console.WriteLine(i); // prints 3
    
          Console.ReadLine();
        }
      }
    
      class LateSetter<T>
      {
        private Action<T> set;
    
        public void SaveSetter(Action<T> setter)
        {
          this.set = setter;
        }
    
        public void SetValue(T i)
        {
          this.set(i);
        }
      }
    }
