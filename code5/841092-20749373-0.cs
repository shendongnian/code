    public class SomeContainer
    {
        public Foo foo { get; set; }
    }
    
    var container = new SomeContainer();
    
    var myValuePath = "foo.bar.baz"; // Get this from the json
    
    string[] propertyNames = myValuePath.Split('.');
    
    object instance = container;
    foreach (string propertyName in propertyNames)
    {
        var instanceType = instance.GetType();
        // Get the property info
    	var property = instanceType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        // Get the value using the property info. 'null' is passed instead of an indexer
    	instance = property.GetValue(instance, null);
    }
    
    // instance will be baz after this loop
