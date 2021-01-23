    class Test {
      public static T runTest<T>(IEnumerable<T> list, Monoid<T> m) {
        list.Aggregate(m.MEmpty, (a, b) => m.MAppend(a, b));
      }
    }
