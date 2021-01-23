    internal List<GroupInfoList<object>> GetGroupsByLetter()
        {
          var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
            var groupByAlphabets = from letter in letters
                       select new
                       {
                           Key = letter,
                           Items = (from item in Collection
                                    where ((Item)item).Station.StartsWith(letter.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                    orderby ((Item)item).Station
                                    group item by ((Item)item).Station[0] into g
                                    select g)
                       };
            List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();
            foreach (var g in groupByAlphabets)
            {
                GroupInfoList<object> info = new GroupInfoList<object>();
                info.Key = g.Key;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }
            return groups;
        }
