    var properties = typeof(TestClass)
                         .GetProperties(BindingFlags.NonPublic | 
                                        BindingFlags.Public | 
                                        BindingFlags.Instance)
                         .Where(p => p.IsDefined(typeof(IncludableAttribute), true)
                         .ToList();
