    protected override void DataRepeater_DrawItem(object sender, 
        DataRepeaterItemEventArgs e)
    {
        var dataSourceEntity = GetObjectFromDataSource(e.DataRepeaterItem);
        var checkedComponent = _checkedItems.SingleOrDefault(
             x => x.Equals(dataSourceEntity));
        
        // Get current item control to fill. Something like
        var grid = e.DataRepeaterItem.Controls["yourgridiew"] as DataGridView;
        
        // Do stuff, you are messing with the right object :)
    }
