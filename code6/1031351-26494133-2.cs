    var dealInfo = new SortedDictionary<string, List<DataRow>>();
    foreach (DataTable table in RecentAddedDeal.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            var dealName = row["DealTab"].ToString();
            if (dealInfo.ContainsKey(dealName))
            {
                dealInfo[dealName].Add(row);
            }
            else
            {
                dealInfo.Add(dealName, new List<DataRow> {row});
            }
        }
    }
