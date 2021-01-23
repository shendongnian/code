    protected void Topic_SelectedIndexChanged(object sender, EventArgs e)
    {
    	try
    	{
    		if (Topic.SelectedIndex == 0)
    		{
    			string query = @"Specialty LIKE '%%'";
    
    			DataTable cacheTable = HttpContext.Current.Cache["cachedtable"] as DataTable;
    			DataTable filteredData = cacheTable.Select(query).CopyToDataTable<DataRow>();
    
    			filteredData.DefaultView.Sort = "Specialty ASC";
    
    			Specialty.DataSource = filteredData.DefaultView.ToTable(true, "Specialty");
    			Specialty.DataTextField = "Specialty";
    			Specialty.DataValueField = "Specialty";
    			Specialty.DataBind();
    		}
    		else
    		{
    			string qpopulate = @"[Topic] = '" + Topic.SelectedItem.Value + "' or [Topic] = 'All Topics'"; //@"Select * from [DB].dbo.[table2] where [Specialty] = '" + Specialty.SelectedItem.Value + "' or [Specialty] = 'All Specialties'";
    			DataTable cTable = HttpContext.Current.Cache["cachedtable2"] as DataTable;
    			DataTable fData = cTable.Select(qpopulate).CopyToDataTable<DataRow>();
    
    			if (fData.Rows.Count > 0)
    			{
    				fData.DefaultView.Sort = "Specialty ASC";
    
    				Specialty.DataSource = fData.DefaultView.ToTable(true, "Specialty");
    				Specialty.DataTextField = "Specialty";
    				Specialty.DataValueField = "Specialty";
    				Specialty.DataBind();
    			}
    			Specialty.Items.Insert(0, new ListItem("All Specialties", "All Specialties"));
    		}
    	}
    	catch (Exception ce)
    	{
    		string error = ce.Message;
    	}
    }
