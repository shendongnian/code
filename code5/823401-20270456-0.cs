    // If Rate and supply both are decimals.
    Use the below code
    
    ds.Tables[0].Columns["Amount"].DefaultValue =Convert.ToDecimal((ds.Tables[0].Columns["Rate"].DefaultValue) * Convert.ToDecimal(ds.Tables[0].Columns["Supply"].DefaultValue); 
    
    // If Rate and supply both are integers.
    
    ds.Tables[0].Columns["Amount"].DefaultValue =Convert.ToInt32((ds.Tables[0].Columns["Rate"].DefaultValue) * Convert.ToInt32(ds.Tables[0].Columns["Supply"].DefaultValue); 
