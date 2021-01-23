    var list = List.GroupBy(x => x.PropA)
                   .SelectMany(grp => grp.Skip(1))
                   .Select(x => x = new MyObject 
                              { 
                                PropA = "", 
                                PropB = "", 
                                PropC = x.PropC
                              })
                   .Union(
                           List.GroupBy(x => x.PropA).Select(grp => grp.First())
                         );
