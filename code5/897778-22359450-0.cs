    string promoIDs = "Test1, Test2, Test3, Test4";
    string[] values = promoIDs.Split(',');
    foreach (string value in values)
    {
        string item = value.Trim(); // Trim the spaces
        lstBoxPromoItems.Items.Add(new ListItem(item, item));
    }
