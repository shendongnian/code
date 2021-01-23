    // Create your object
    dynamic myObject2 = new ExpandoObject();
    
    // Cast to IDictionary<string, object>
    var myObjectDictionary = (IDictionary<string, object>)myObject2;
    // Get List<string> of properties
    var propertyNames = myObjectDictionary.Keys.ToList();
