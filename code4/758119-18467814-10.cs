    // instance methods:
    var languages = new Languages();
    var properties = languages.GetProperties(); // prop1,prop2,prop3
    var fields = languages.GetFields(); // field1,field2,field3
    var propAndValue = languages.GetPropertyValueDictionary(); // Dict<propertyName,value>
    var fieldAndValue = languages.GetFieldValueDictionary(); // Dict<fieldName,value>
    // non-instance methods:
    var properties = ObjectExtensions.GetPropertiesFor<Languages>(); // prop1,prop2,prop3
    var fields = ObjectExtensions.GetFieldsFor<Languages>(); // field1,field2,field3
