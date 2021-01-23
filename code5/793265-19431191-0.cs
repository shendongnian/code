        internal List<GroupInfoList<object>> GetGroupsByLetter() 
        { 
            List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>(); 
 
            var query = from item in Collection 
                        orderby ((Item)item).Title 
                        group item by ((Item)item).Title[0] into g 
                        select new { GroupName = g.Key, Items = g }; 
            foreach (var g in query) 
            { 
                GroupInfoList<object> info = new GroupInfoList<object>(); 
                info.Key = g.GroupName; 
                foreach (var item in g.Items) 
                { 
                    info.Add(item); 
                } 
                groups.Add(info); 
            } 
 
            return groups; 
 
        } 
    } 
