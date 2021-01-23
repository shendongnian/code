    abstract class Base
    {
    ...
      public static T getInstance<T>() where T : Base
      {
        Type callingType = typeof(T);
        // no need to check type; T will always be a type of or derived from Base
        return AllInstances.Find(i => i.GetType() == callingType) as T;
      }
    }
