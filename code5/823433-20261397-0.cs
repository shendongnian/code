    try
    {
        cmdbl = new SQLiteCommandBuilder(adap);
        adap.Update(ds, "Items");
        dtgItems.Items.Refresh();
    }
    catch (Exception ex)
    {
    }
