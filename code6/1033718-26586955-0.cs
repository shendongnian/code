    var result = (from item in list
                 group item by item.GroupId into grp
                 select new
                 {
                      GroupId = grp.Key,
                      Count = grp.Count()
                 })
                 .ToList().Aggregate((a,b) => (a.Count)*(b.Count));
