    string column = 'dob'; // This is dynamic
    
    var data = ctx.tblTable
                        .Where(e => e.Id == Id && e.Name == name)
                        .ToList()
                        .Select(e => GetPropValue(e, column))
                        .FirstOrDefault();
    public object GetPropValue(object obj, string propName)
    {
         return obj.GetType().GetProperty(propName).GetValue(obj, null);
    }
