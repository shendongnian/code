    protected void ListView1_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
    
    {
        if ((sender as ListView) != null)
            {
        
                ListView l = (ListView)sender;
                l.SelectedIndex;
                l.etc..............
                DataKey key = l.SelectedDataKey;
                object k = key.Values["DarkhastId"];        
            }
    
    
    }
    
