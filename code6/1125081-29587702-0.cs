     var typesWithYear = AppDomain.CurrentDomain
                                  .GetAssemblies()
                                  .SelectMany(a=>a.GetTypes())
                                  .Where(t=>typeof(IHasYearColumn)
                                              .IsAssignableFrom(t))
                                  .Where(t => t.IsClass && !t.IsAbstract);
