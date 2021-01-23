    public class ClassName
    {
      public KeyValuePair<string, object> PropertyName {get; set; }
    }
    
    var c = new ClassName();
    c.PropertyName = new KeyValuePair<string, object>("keyName", someValue);
