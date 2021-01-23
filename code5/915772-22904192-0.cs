    static public class Extensions
    {
      static T ExampleGet<T>(this ParseObject po, string name)
      {
          return po.Get<T>(name);
      }
    }
