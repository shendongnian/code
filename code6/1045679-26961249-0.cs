    Type myType = form.GetType();
    IList<FieldInfo> props = new List<FieldInfo>(myType.GetFields());
    
    object fValue;
    foreach (FieldInfo f in props)
    {
        if(f.Name == "dllTitle")
        {
            fValue = f.GetValue(form, null);
            break;
         }
    }
