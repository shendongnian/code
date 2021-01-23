    public class Foo<T>
    {
      // since we can't check T at compile-time anymore (no constraint), we do this
      static Foo()
      {
        if (!typeof(IPclCloneable).IsAssignableFrom(typeof(T)) && !typeof(T).IsArray)
          throw new ArgumentException("Type must have Clone method", "T");
      }
      public void Bar(T item)
      {
          var x = item.Clone();
          ...
      }
    }
    public static class YourExtensions
    {
      public static object Clone(this object obj)
      {
        if (obj == null)
          throw new ArgumentNullException("obj");
        var objIPclCloneable = obj as IPclCloneable;
        if (objIPclCloneable != null)
          return objIPclCloneable.Clone();
        var objArray = obj as Array;
        if (objArray != null)
          return objArray.Clone();
        throw new ArgumentException("Type of 'this' must have Clone method", "obj");
      }
    }
  
    public interface IPclCloneable
    {
      object Clone();
    }
