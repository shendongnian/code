    protected void gridView_1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string surname = e.NewValues[0].ToString(); /* NewValues is the key */
                
        string id = gridView_1.DataKeys[e.RowIndex].Values[0].ToString(); /* get the id */
    
        sqlDataSource_1.UpdateCommand = "[storedProcedure_Update_Surnames] " + id + ", '" + surname +"'"; 
    }  
