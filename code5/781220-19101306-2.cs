    PropertyInfo fieldPropertyInfo = businessObject.GetType().GetProperties()
                                     .FirstOrDefault(f => f.Name.ToLower() == piecesLeft[0].ToLower());
    
    // The result should be stored into another variable here:
    businessObject = fieldPropertyInfo.GetValue(businessObject, null);
    fieldPropertyInfo.SetValue(businessObject, replacementValue, null);
