    List<string> vals = new List<string>();
    vals.AddRange(filterValue.Split(new char[]{','}));
    List<T> bindingEntities = entities.Where(
                                             e => e.ExtraProperties.Values.Any(
                                                 val => vals.Contains(val.ToString())))
                                      .ToList();
