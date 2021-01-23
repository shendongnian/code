    foreach (TabelRow row in Table1.Rows)
    {
    	if(row.Cells.Count > 0)
    	{
    		if (row.Cells[1].Controls.Count > 0 && row.Cells[1].Controls[0].GetType() ==  typeof(DropDownList))
    		{
    			Response.Write(a.SelectedValue); 
    		}
    	}
    }
