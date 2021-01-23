    foreach(var option in new[] {"ContactPerson", "ContactPersonTitle" }){
       if (type.StartsWith(option))
       {
            Type t = Type.GetType(item.GetMethod.ReturnParameter.ParameterType.ToString());
            item.SetValue(returnVal, Convert.ChangeType(record[item.Name].ToString(), t));
       }
    }
