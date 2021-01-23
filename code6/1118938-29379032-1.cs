    Assembly assembly = Assembly.ReflectionOnlyLoad("Parser");
    var results = assembly.GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .SelectMany(m => CustomAttributeData.GetCustomAttributes(m)
                  .Where(c => c.AttributeType.FullName == typeof(RPCAttributeType).FullName))
                  .ToList();
    ShowAttributeData(results);
