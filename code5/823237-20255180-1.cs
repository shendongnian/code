    var newlist1 = (MyList.Where(li => li.State == "NY")
                   .OrderBy(li => li.Id)
                   .Select((li, idx) => new {itm = li, val = li.Id - idx})
                   .GroupBy(nw => nw.val)
                   .Select(g => new { Min = g.Min(nw => nw.itm.Id), 
                                      Max = g.Max(nw => nw.itm.Id)})
                    ).ToList();
