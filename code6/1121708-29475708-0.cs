    DataSet ds = new DataSet();
    byte[] strAsBytes = new System.Text.UTF8Encoding().GetBytes(strYourXml);
    System.IO.MemoryStream ms = new System.IO.MemoryStream(strAsBytes);
    
    ds.ReadXml(ms);
    
    if ((ds.Tables("Product") != null)) {
    	foreach (DataRow t_row in ds.Tables("Product").Rows) {
    		'// determine which row you want to
    		'// modify by checking against values here.
    		'// set a variable to target_row, then exit for loop
    	}
    }
    
    ds.Tables("Product").Rows(target_row)("Pieces") = 42;
    
    
    strYourXml = ds.GetXml;
