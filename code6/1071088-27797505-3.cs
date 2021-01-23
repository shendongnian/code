    dt = dt.AsEnumerable()
        .GroupBy(r => new {
            RefDescription = r.Field<string>("RefDescription"),
            ReferenceUrl = r.Field<string>("ReferenceUrl")
        })
        .Select(grp =>
        {
            DataRow first = grp.First();
            if (grp.Skip(1).Any())
            {
                // duplicates
                string otherSortOrders = String.Join(",", grp.Skip(1).Select(r => r.Field<int>("SortOrder")));
                first.SetField("RefDescription", string.Format("{0} {1}",
                    otherSortOrders,
                    grp.Key.RefDescription));
            }
            return first;
        }).CopyToDataTable();
