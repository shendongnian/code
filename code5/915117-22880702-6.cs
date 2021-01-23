    protected void ListView1_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
    
    {
        if ((sender as ListView) != null)
            {
        
                ListView l = (ListView)sender;
                int Index = ListView1.EditIndex;
                 DataKey DK = ListView1.DataKeys[Index]["DarkhastId"];
                string url="showprofile.aspx?DarkhastId="+DK.Value.ToString();
      Response.Redirect(url);
                
                 
            }
    }
    
