    private static Dictionary<string, string> DumpModel(object obt)
            {
                Type type = obt.GetType();
                if (TypeDefinitionIsList(type))
                    return null;
    
                PropertyInfo[] properties = obt.GetType().GetProperties();
                Func<PropertyInfo, string> func = info =>
                                                      {
                                                          if (info.PropertyType.GetInterface(typeof (ICatalogue<>).FullName) != null)
                                                          {
                                                              dynamic propertyValue = info.GetValue(obt, null);
                                                              if (propertyValue != null)
                                                                  return string.Format("{{ Id: {0}, Description: {1} }}",
                                                                                       propertyValue.Id,
                                                                                       propertyValue.Description);
                                                              return "null";
                                                          }
                                                          object normalValue = info.GetValue(obt, null);
                                                          if (normalValue == null) return "null";
                                                          return TypeDefinitionIsList(normalValue.GetType()) ? HelpersMessages.NotSupportedList : normalValue.ToString();
                                                      };
    
                return properties.ToDictionary(x => "model-"+x.Name, func);
            }
