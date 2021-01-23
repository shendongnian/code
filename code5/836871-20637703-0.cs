    List<Property> list = new List<Property>();
    var result = list.GroupBy(r => r.Name)
                    .Select(r => new 
                            { 
                                Name = r.Key, 
                                Values = string.Join(",", r.Select(t => t.Value)) 
                            });
