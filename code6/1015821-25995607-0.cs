    List<string> uidClassificationList = new List<string>();
    using (IDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            uidClassificationList.Add(reader.GetString("uidClassification"));
        }
    }
    foreach(ListItem item in vendorType.Items)
        item.Selected = uidClassificationList.Contains(item.Value);
