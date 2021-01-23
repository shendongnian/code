    StringBuilder sb = new StringBuilder();
    if (ds.Tables != null && ds.Tables.Count > 0)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
        {
            ....
        }
        Literal1.Text = sb.ToString();
    }
    else
    {
        // do something when ds.Tables is null or ds.Tables doesn't have any elements
    }
