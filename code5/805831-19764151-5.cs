     var results = rows.GroupBy(row => new { row.TagNo, row.FromBay, row.FromPanel})
                       .OrderBy(g => g.Key.TagNo)
                       .ThenBy(g => g.Key.FromBay)
                       .ThenBy(g => g.Key.FromPanel)
                       .Select((g,i) => new {
                                        key = g.Key,i,              
                                        sub = g.GroupBy(x=>x.FDevice).OrderBy(g=>g.Key)
                                               .Select(g=>g.Select((x,j)=>new{x,j}))
                                       })                               
                       .SelectMany(e=> e.sub, (e,c)=> new {
                                    TagNo = e.i == 0 ? e.key.TagNo.ToString() : "",
                                    FromBay = e.i == 0 ? e.key.FromBay : "",
                                    FromPanel = e.i == 0 ? e.key.FromPanel : "",
                                    FDevice = c.j == 0 ? c.x.FDevice : "",
                                    FRef = c.x.FRef,
                                   });
