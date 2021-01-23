    if (field.Contains(".")) {
       var parts = field.Split('.');
       var fieldName = parts[0];
       List<string> toGet = new List<string>();
       toGet.Add(parts[1]); // this now contains everything after the "." 
       var fieldValue = employee.GetType()
            .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
            .GetValue(employee, null);
       FilteringProperties(fieldValue, toGet);
    }
