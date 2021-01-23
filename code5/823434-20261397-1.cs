    try
    {
        cmdbl = new SQLiteCommandBuilder(adap);
        adap.Update(ds, "Items");
        ds.Tables[0].AcceptChanges();
        dtgItems.Items.Refresh();
    }
    catch (Exception ex)
    {
    }
