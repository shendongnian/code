    List<Item> removedItems = dc.Items.Where(o => o.Removed).ToList();
    foreach (Item item in removedItems)
    {
        try
        {
            dc.Items.DeleteOnSubmit(item);
            dc.SubmitChanges();
        }
        catch 
        { 
            dc.StatisticsSettings.InsertOnSubmit(item);
        }
    }
}
