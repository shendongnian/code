    DataSet ds = new DataSet();
    byte[] strAsBytes = new System.Text.UTF8Encoding().GetBytes(strYourXml);
    System.IO.MemoryStream ms = new System.IO.MemoryStream(strAsBytes);
    
    ds.ReadXml(ms);
    
    string serach_name = "Urdu Book";
    string new_value = 42;
    
    if ((ds.Tables("Product") != null)) {
    
    	foreach (DataRow t_row in ds.Tables("Product").Rows) {
    		if ((t_row("Name") == serach_name)) {
    			t_row("Price") = new_value;
    			break; 
    		}
    
    	}
    }
