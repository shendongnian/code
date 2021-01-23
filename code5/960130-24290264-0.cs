    //Usage
    DataTable dtMod = GetModifiedTable( dt);
    
    //Function to return modified data table
    public DataTable GetModifiedTable(DataTable dt)
    {
    	var columnList = dt.Columns.Cast<DataColumn>()
    								 .Where(x => x.ColumnName.StartsWith("Tag"))
                                     .Select(x => x.ColumnName)
    								 .ToArray();
    								 
    	DataTable dtNew = new DataTable();
    	dtNew.Columns.Add("FName");
    	dtNew.Columns.Add("LName");
    	dtNew.Columns.Add("Tag_All");
    	
    	var results  = dt.AsEnumerable().Select(r => 
    					   dtNew.LoadDataRow( 
    					   	 new object[] { 
                                    r.Field<string>("FName"),
                                    r.Field<string>("LName"),
                                    GetTagValues(r, columnList)
    		                              
                                  }, false
    						));
    					
    	dtNew.Rows.Add(results.ToArray());
    	
    	return dtNew;
    }
    
    //Function to return csv values of given column list
    public string GetTagValues(DataRow r, string[] columns )
    {
    	string csv = string.Empty;
    	foreach(string column in columns)
    	{
    		csv += r[column].ToString() + ",";
    	}
    	return csv.Substring(0, csv.Length - 1);
    }
