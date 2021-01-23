    var matched = from mainTable in mainDataTable.AsEnumerable()
                          join keyTable in keyWordTable.AsEnumerable() on mainTable.Field<int>("ID") equals keyTable.Field<int>("ID")
                          where !mainTable.Field<string>("Description").Contains(keyTable.Field<string>("KeyWord"))
                          select mainTable;
            if (matched.Count() > 0)
            {
                DataTable finalTable = matched.CopyToDataTable();
            }
