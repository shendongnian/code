    List<ITemplate> allTemplates
                  = objects.Where(o => o.GetType()                                                                              
                                        .GetInterfaces()
                                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITemplateInstance<>)))
                           .Select(o => o.GetType()
                                         .GetProperty("TemplateReference")
                                         .GetValue(o))
                           .OfType<ITemplate>()
                           .ToList();
