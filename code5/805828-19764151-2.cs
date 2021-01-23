     var results = rows.GroupBy(row => new { row.TagNo, row.FromBay, row.FromPanel})
                       .OrderBy(g => g.Key.TagNo)
                       .ThenBy(g => g.Key.FromBay)
                       .ThenBy(g => g.Key.FromPanel)
                       .Select((g,i) => new {
                                        key = g.Key,i,              
                                        sub = g.GroupBy(x=>x.FDevice).OrderBy(g=>g.Key)
                                               .Select((e,j)=> new {e,j})
                                       })                               
                       .SelectMany(e=> e.sub, (e,c)=> new {
                                    TagNo = e.i == 0 ? e.Key.TagNo.ToString() : "",
                                    FromBay = e.i == 0 ? e.Key.FromBay : "",
                                    FromPanel = e.i == 0 ? e.Key.FromPanel : "",
                                    FDevice = c.j == 0 ? c.e.Key : "",
                                    FRef = c.e.FRef,
                                   });
