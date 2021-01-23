    var hierarchyDataList = 
    list
     .GroupBy(x => x.ParentId)
     .Select(g => new HierarchyData
                      {
                          Parent = new Person
                                       {
                                           Id = g.Key
                                       },
                          Children = g.Select(x => new Person 
                                                       { 
                                                           Id = x.ChildId, 
                                                           Name = x.ChildName
                                                       }
                                             )
                      }
            );
