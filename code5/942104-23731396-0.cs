        DataTable dt = new DataTable();
    	dt.Columns.Add("id");
    	dt.Columns.Add("pid");
    	dt.Columns.Add("pname");
    	dt.Columns.Add("pamountex",typeof(int));
    	dt.Columns.Add("vat",typeof(int));
    	
    	dt.Rows.Add( new object[] { 1, 4, "t1", 123, 2 } );
    	dt.Rows.Add( new object[] { 2, 3, "t2", 45, 3 } );
    	dt.Rows.Add( new object[] { 3, 4, "t3", 56, 7 } );
    	dt.Rows.Add( new object[] { 4, 3, "t4", 23, 8 } );
    
    	dt.AsEnumerable()
    		.GroupBy(r => r.Field<string>("pid") )
    		.Where (r => r.Count() > 1)
    		.Select (gr => 
    			new { id = 0, 
    				  pid = gr.Key, 
    				  pname = "???", 
    				  pamountex = gr.Sum (g => g.Field<int>("pamountex")), 
    				  vat = gr.Sum (g => g.Field<int>("vat"))
    				})
    		.ToList()
    		.ForEach( r => dt.Rows.Add( 
                     new object[] { 
                             r.id, 
                             r.pid, 
                             r.pname, 
                             r.pamountex, 
                             r.vat } ));
