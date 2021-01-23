    DataTable dtInput = new DataTable();
    dtInput.Columns.Add("Id");
    dtInput.Columns.Add("RefId");
    dtInput.Columns.Add("Name");
    
    DataTable dtOutput = new DataTable();
    dtOutput.Columns.Add("RefId");
    Enumerable.Range(1,7).ToList()
    	.ForEach( i => { dtOutput.Columns.Add("Name"+i ); dtOutput.Columns.Add("Id"+i ); }  );
    	
    dtInput.Rows.Add( new object[] { "1", "1", "Test1" } );
    dtInput.Rows.Add( new object[] { "2", "1", "Test2" } );
    dtInput.Rows.Add( new object[] { "3", "1", "Test3" } );
    dtInput.Rows.Add( new object[] { "4", "2", "Test4" } );
    dtInput.Rows.Add( new object[] { "5", "2", "Test5" } );
    
    dtInput.AsEnumerable()
    	.GroupBy(x => new { RefId = x["RefId"] })
    	.Select(x => new { RefId = x.Key.RefId, 
    						Names = x.Select(x1 => x1["Name"]), 
    						Ids = x.Select(x1 => x1["Id"])})
    	.ToList().ForEach( g =>
    		{
    			var row = dtOutput.NewRow();
    			row["RefId"] = g.RefId;
    			g.Names.Select( (n, idx) => new { idx = idx + 1, name = n } )
    				.ToList().ForEach( n => row["Name"+n.idx] = n.name );
    			g.Ids.Select( (i, idx) => new { idx = idx + 1, id = i } )
    				.ToList().ForEach( i => row["Id"+i.idx] = i.id );
    			dtOutput.Rows.Add( row );
    		});
