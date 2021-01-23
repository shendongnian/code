    List<string> uidClassificationList = new List<string>();
    using (IDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            int column = reader.GetOrdinal("uidClassification");
            uidClassificationList.Add(reader.GetInt32( column ).ToString());
        }
    }
    foreach(ListItem item in vendorType.Items)
        item.Selected = uidClassificationList.Contains(item.Value);
