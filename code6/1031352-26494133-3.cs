    var dealInfo = new SortedDictionary<string, List<DataRow>>();
    foreach (DataTable table in RecentAddedDeal.Tables)
    {
        if (!dealInfo.ContainsKey(table.TableName))
        {
            dealInfo.Add(table.TableName, table.Rows.Cast<DataRow>().ToList());
        }
    }
