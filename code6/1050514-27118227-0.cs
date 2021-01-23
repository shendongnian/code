    private void Regions_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // Get the currently selected item in the ListBox. 
       string region = Regions.SelectedItem.ToString();
    
       // Find the divisions in the region
       IEnumerable<string> divisions = GetDivisionsInRegion(region);
    
       //set as this as the new data source for your Divisions listbox
       Divisions.DataSource = divisions;
    }
