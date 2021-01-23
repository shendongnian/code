    static string GetId(Type t) {
       // you can have all kind logic to autowire up, ie use some convention
       t.GetProperties().Select(p => p.CustomAttributes).Dump();
       return t.GetProperties()
              .Where(p => p.Name
                          .Equals("Id",StringComparison.OrdinalIgnoreCase) ||
                          p.CustomAttributes.Any(ca => ca.AttributeType == typeof(Value)) 
       ).Select(p=>p.Name).First();
    }
