    using System;
    namespace ConsoleApplication1 {
      public enum MyEnumType {
        One = 1,
        Two = 2,
        Three = 3,
      }
      public static class Extension {
        public static string ToLocalizedString(this MyEnumType type) {
          // check System.Threading.Thread.CurrentThread.CurrentCulture 
          // if you need current culture context
          switch (type) {
            case MyEnumType.One:
              return "Ein";
            case MyEnumType.Two:
              return "Zwei";
            case MyEnumType.Three:
              return "Drei";
            default:
              throw new NotImplementedException();
          }
        }
      }
      class Program {
        static void Main(string[] args) {
          var foo = MyEnumType.One;
          Console.Out.WriteLine(foo.ToLocalizedString());
        }
      }
    }
