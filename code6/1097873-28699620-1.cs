    using System;
    using System.Collections.Generic;
    using System.Linq; // **OUTSIDE**
    namespace Me.MyName
    {
      using System.MySuperLinq; // **INSIDE**
      static class Test
      {
        static void Main()
        {
          (new[] { "Hans", "Birgit" }).Where(x => x == "Hans");
        }
      }
    }
    namespace System.MySuperLinq
    {
      static class Extensions
      {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
          Console.WriteLine("My own MySuperLinq method");
          return null; // will fix one day
        }
      }
    }
    namespace Me.MyName
    {
      static class Extensions
      {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
          Console.WriteLine("My own MyName method");
          return null; // will fix one day
        }
      }
    }
    namespace Me
    {
      static class Extensions
      {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
          Console.WriteLine("My own Me method");
          return null; // will fix one day
        }
      }
    }
    // this is not inside any namespace declaration
    static class Extensions
    {
      public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
      {
        Console.WriteLine("My own global-namespace method");
        return null; // will fix one day
      }
    }
