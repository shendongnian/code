    protected void rg_OnItemCommand(object source, GridCommandEventArgs e)
    {
       // your logic 
       hdFlag.value = "val" // id of the data item to hide if more than one use array
      // rebind logic for gird
    }
    protected void rg_ItemDataBound(object sender, GridItemEventArgs e)
    {
      if(hdFlag.value == "id")
      {
        // Find the control and hide 
      }
    }
