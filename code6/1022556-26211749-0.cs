    string column = 'dob'; // This is dynamic
    
    var data = ctx.tblTable
                        .SingleOrDefault(e => e.Id == Id && e.Name == name)
                        .Select(e => GetPropValue(e, column);
    public object GetPropValue(object obj, string propName)
    {
         return obj.GetType().GetProperty(propName).GetValue(obj, null);
    }
