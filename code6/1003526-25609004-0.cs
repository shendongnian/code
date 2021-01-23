    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class MarkerAttribute : Attribute {
      public string UrlAction { get; private set; }
      public MarkerAttribute(string urlAction) {
        if (string.IsNullOrEmpty(urlAction)) {
          throw new ArgumentNullException("urlAction");
        }
        UrlAction = urlAction;
      }
    }
    [Marker("apple")]
    public class Foo1 {
    }
    [Marker("banana")]
    public class Foo2 {
    }
    // now the Foo3 will be marked as banana
    public class Foo3 : Foo2 {
    }
    // now the Foo3 will be marked as orange
    [Marker("orange")]
    public class Foo3 : Foo2 {
    }
    
    var typeDictionary = 
      (from t in Assembly.GetExecutingAssembly().GetTypes()
       where t.GetCustomAttributes(typeof(MarkerAttribute), true) != null && 
             t.GetCustomAttributes(typeof(MarkerAttribute), true).Length > 0
       select new {
         Type = t,
         Action = ((MarkerAttribute)t.GetCustomAttributes(typeof(MarkerAttribute), true)[0]).UrlAction
     }).ToDictionary(k => k.Type, v => v.Action);
