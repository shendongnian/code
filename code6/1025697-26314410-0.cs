    using System;
    using System.Reflection;
    abstract class C { }
    static class Program {
      static void Main() {
        // prints nothing: C has no public constructor
        Console.WriteLine(typeof(C).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null));
        // does print: C does have a non-public constructor
        Console.WriteLine(typeof(C).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null));
      }
    }
