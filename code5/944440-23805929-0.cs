    using System;
    using System.Linq;
    namespace test {
      class Program {
        interface IMyInterface<T> { }
        class MyClass<T> : IMyInterface<T> { }
        private static void Print(Type xType) {
          unsafe {
            fixed (char* c = xType.Name) {
              long lAddress = (long)c;
              Console.WriteLine(lAddress);
            }
          }
        } //
        static void Main(string[] args) {
          Type type1 = typeof(IMyInterface<>);
          Type type2 = typeof(IMyInterface<object>).GetGenericTypeDefinition();
          Type type3 = typeof(MyClass<>).GetInterfaces().Single();
          Type type4 = typeof(MyClass<object>).GetInterfaces().Single().GetGenericTypeDefinition();
          Type type5 = typeof(MyClass<object>).GetGenericTypeDefinition().GetInterfaces().Single();
     
          Print(type1); // 34060364
          Print(type2); // 34060364
          Print(type3); // 34062812
          Print(type4); // 34060364
          Print(type5); // 34062812     
          // therfore:
          // type1 == type2 == type4
          // and
          // type3 == type5
          Console.WriteLine("type1 == type2  " + type1.Equals(type2)); // true
          Console.WriteLine("type1 == type4  " + type1.Equals(type4)); // true
          Console.WriteLine("type2 == type4  " + type2.Equals(type4)); // true
          Console.WriteLine("type3 == type5  " + type3.Equals(type5)); // true
          Console.WriteLine("type1 == type5  " + type1.Equals(type5)); // false
          Console.WriteLine("type2 == type5  " + type2.Equals(type5)); // false
          Console.WriteLine("type4 == type5  " + type4.Equals(type5)); // false
          Console.WriteLine("type3 == type4  " + type3.Equals(type4)); // false
          Console.WriteLine("type1 == type3  " + type1.Equals(type3)); // false
          Console.WriteLine("type2 == type3  " + type2.Equals(type3)); // false
          // the names are the same, but the objects are not
          Console.WriteLine(type1.Name.ToString());
          Console.WriteLine(type2.Name.ToString());
          Console.WriteLine(type3.Name.ToString());
          Console.WriteLine(type4.Name.ToString());
          Console.WriteLine(type5.Name.ToString());            
     /* example output:
    38778956
    38778956
    38781404
    38778956
    38781404
    type1 == type2  True
    type1 == type4  True
    type2 == type4  True
    type3 == type5  True
    type1 == type5  False
    type2 == type5  False
    type4 == type5  False
    type3 == type4  False
    type1 == type3  False
    type2 == type3  False
    IMyInterface`1
    IMyInterface`1
    IMyInterface`1
    IMyInterface`1
    IMyInterface`1
    */
          Console.ReadLine();
        }
      }
    }
