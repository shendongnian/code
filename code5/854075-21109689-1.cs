    var fields = typeof(Class2)
                 // Get Properties of the ClassB
                 .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                 // Map each PropertyInfo into collection of its values from c1.dictObj2
                 .SelectMany(pi => mainClass.listObj1
                                            .SelectMany(c1 => c1.dictObj2)
                                            .Select(p => new
                                                     {
                                                       Property = pi.Name,
                                                       Value = pi.GetValue(p.Value)
                                                     }))
                 // Group data with respect to the PropertyName
                 .GroupBy(x => x.Property, x => x.Value)
                 // And create proper dictionary
                 .ToDictionary(x => x.Key, x => x.ToList());
