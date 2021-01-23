    private CultureInfo enUS = new CultureInfo("en-US"); 
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	// check if it is a row that contains data
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		// convert the dataItem to your datasource type with a safe cast
    		DataRowView row = e.Row.DataItem as DataRowView;
    
    		// check if the conversion was succeed
    		if (row != null)
    		{
    			// check if the date column is not null
    			if (row["ExpiryDate"] != null)
    			{
    				// try to convert the string into a datetime with a specific format (i am not sure about the date format you are using)
    				DateTime dt;
    				if (DateTime.TryParseExact(row["ExpiryDate"], "mm/DD/yyyy", enUS, DateTimeStyles.None, out dt))	
    				{
    					// conversion looks ok, do your task					
    					int compareResult = DateTime.Compare(DateTime.Now, dt);
    					e.Row.BackColor = compareResult == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White; 
    				}
    			}  		
    		}
    	}
    }
