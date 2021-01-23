    // Your classes
    public class PropertyInfoAttribute: Attribute {
      public bool IsAutoComplete {
        get;
        set;
      }
    }
    
    public class Article {
      public virtual int Order {
        get;
        set;
      }
    }
    
    public class ArticleDetails: Article {
      [PropertyInfo(IsAutoComplete = true)]
      public override int Order {
        get;
        set;
      }
    }
    
    ...
    // My test
    
    // Let's do it explicitly:
    // ask for public and instance (not static) property
    PropertyInfo pi = typeof(ArticleDetails).GetProperty("Order", BindingFlags.Public | BindingFlags.Instance);
    // Then ask for the attribute
    Attribute at = pi.GetCustomAttribute(typeof(PropertyInfoAttribute));
    
    // And, finally, check if attribute is existing
    // ... And so, assertion passes - attribute is existing
    Trace.Assert(!Object.ReferenceEquals(null, at), "No Attribute found.");
