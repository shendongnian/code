    PropertyInfo fieldPropertyInfo = businessObject.GetType().GetProperties()
                                     .FirstOrDefault(f => f.Name.ToLower() == piecesLeft[0].ToLower());
    
    // also you should check if the propertyInfo is assigned, because the 
    // given property looks like a variable.
    if(fieldPropertyInfo == null)
        throw new Exception(string.Format("Property {0} not found", f.Name.ToLower()));
    // you are overwriting the original businessObject
    var businessObjectPropValue = fieldPropertyInfo.GetValue(businessObject, null);
    fieldPropertyInfo.SetValue(businessObject, replacementValue, null);
