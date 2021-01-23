    DataTable dt = new DataTable("UserAcess");
    
    DataColumn dc1 = new DataColumn("PageName");
    dt.Columns.Add(dc1);
    
    foreach (var item in RoleName)
    {   
    	DataColumn  dc = new DataColumn(item.RoleName, typeof(bool));
    	dt.Columns.Add(dc);                      
    }
    
    foreach (var page in pageName)
    {
    	DataRow dr = dt.NewRow();
    	dr["PageName"] = page.PAGE_NAME; 
    	
    	foreach (var role in RoleName)
    	{                  
    		dr[role.RoleName] = true; 
    	}
    	dt.Rows.Add(dr);
    }    
    
    NewDataGrid.DataSource = dt;
    NewDataGrid.DataBind();
