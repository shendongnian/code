    var grps = from row in dt.AsEnumerable()
               let RefDescription = row.Field<string>("RefDescription")
               let ReferenceUrl = row.Field<string>("ReferenceUrl")
               group row by new { RefDescription, ReferenceUrl } into groups
               select groups;
    dt = grps.Select(g => 
         {
            DataRow first = g.First();
            if (g.Skip(1).Any())
            {
                // duplicates
                string otherSortOrders = String.Join(",", g.Skip(1).Select(r => r.Field<int>("SortOrder")));
                first.SetField("RefDescription", string.Format("{0} {1}",
                    otherSortOrders,
                    g.Key.RefDescription));
            }
            return first;
         })
        .CopyToDataTable();
