    protected void ListView1_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
    
    {
        if ((sender as ListView) != null)
            {
        
                ListView l = (ListView)sender;
                
               int i = (int)ListView1.DataKeys[l.SelectedIndex]["DarkhastId"];        
            }
    
    
    }
    
