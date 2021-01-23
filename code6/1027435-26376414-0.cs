    // Create dynamic object from JSON string
    dynamic obj = DynamicJsonConverter.CreateSerializer().Deserialize("JSON STRING", typeof(object));
    // Get json value
    string str = obj.someValue;
    // Get list of members
    IEnumerable<string> members = (IDictionary<string, object>)obj).Keys
    
