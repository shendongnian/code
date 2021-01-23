    var idProp = tempObject.GetType().GetProperty("ID");
    if(idProp == null)
        idProp = tempObject.GetType().GetProperty("Id");
    if(idProp != null)
        idProp.SetValue(tempObject, ID);
