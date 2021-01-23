    IQuery query = container.Query();
    IEnumerable allObjects = query.Execute();
    
    foreach(Object item : allObjects){
        GenericObject dbObject = (GenericObject)item; // Note: If db4o finds actuall class, it will be the right class, otherwise GenericObject. You may need to do some checks and casts
        dbObject.GetGenericClass().GetDeclaredFields(); // Find out fields
        object fieldData = dbObject.Get(0); // Get the field at index 0. The GetDeclaredFields() tells you which field is at which index
    }
