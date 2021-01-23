    using System;
    using System.Collections.Generic;
    namespace Test {
      public class Ptr<T> where T : struct {
        public T Value { get; set; }
      }
  
      class Program {
        static void Main(string[] args) {
          var a = new List<Ptr<int>>();
          var b = new List<Ptr<int>>();
          var ptr = new Ptr<int> { Value = 7 };
          a.Add(ptr);
          b.Add(ptr);
          a[0].Value = 3;
          Console.Out.WriteLine(b[0].Value);
        }
      }
    }
