    var addressType = business.Address.GetType();
    
    foreach (var line in businessCRM.Description
                                    .Split(new[] { "\n", Environment.NewLine },
                                                  StringSplitOptions.RemoveEmptyEntries))
    {
        var propSelectorIndex = line.IndexOf(":");
        if (propSelectorIndex == -1) continue;
    
        var propName = line.Subtring(0, propSelectorIndex);
        var propInfo = addressType.GetProperties(BindigsFlag.Public 
                                                          | BindigsFlag.Instance)
                                  .FirstOrDefault(prop => prop.Name == propName);
    
        if (propInfo == null) throw new InvalidOperationException();
    
        var newPropValue = line.Substring(propSelectorIndex + 2); 
                     // + 2 to omit : char and additional space
        propInfo.SetValue(business.Address, newPropValue, null);
    }
