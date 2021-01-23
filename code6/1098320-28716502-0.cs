    using System;
    using System.Reflection;
    enum Foo { A, B, C };
    static class Program {
      static void Main() {
        foreach (var field in typeof(Foo).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
          Console.WriteLine("Found instance field \"" + field.Name + "\" of type \"" + field.FieldType.FullName + "\"");
      }
    }
