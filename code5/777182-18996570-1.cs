    public void Save()
    {
        var tempObject = Activator.CreateInstance(ObjectType);
        var idProp = tempObject.GetType().GetProperty("ID");
        if(idProp == null)
            idProp = tempObject.GetType().GetProperty("Id");
        if(idProp != null)
            idProp.SetValue(tempObject, ID);
        Views.ToList().ForEach(v =>
        {
            var cv = (v as IAdd);
            var f = tempObject.GetType().GetProperty(cv.Field);
            f.SetValue(tempObject, cv.Value);
        });
        //Database update
        SaveHelpers.SaveObject(tempObject);
        Navigator.Nav.Back();
    }
