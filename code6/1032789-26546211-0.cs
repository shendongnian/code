    void Main()
    {
    	var overtime = new DataTable();
    	overtime.Columns.Add("ID", typeof(int));
    	overtime.Columns.Add("Log Date", typeof(string));
    	overtime.Columns.Add("F1", typeof(string));
    	overtime.Columns.Add("F2", typeof(string));
    	
    	var dv = new DataTable();
    	dv.Columns.Add("User ID", typeof(int));
    	dv.Columns.Add("Log Date", typeof(string));
    	dv.Columns.Add("Type", typeof(string));
    	dv.Columns.Add("Time", typeof(string));
    	
    	var row = dv.NewRow();
    	row["User ID"] = 0000000002;
    	row["Log Date"] = "2014/10/16";
    	row["Type"] = "F1";
    	row["Time"] = "09:03:13";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000002;
    	row["Log Date"] = "2014/10/16";
    	row["Type"] = "F2";
    	row["Time"] = "17:02:20";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000002;
    	row["Log Date"] = "2014/10/18";
    	row["Type"] = "F1";
    	row["Time"] = "08:38:42";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000002;
    	row["Log Date"] = "2014/10/19";
    	row["Type"] = "F2";
    	row["Time"] = "16:55:02";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000002;
    	row["Log Date"] = "2014/10/19";
    	row["Type"] = "F1";
    	row["Time"] = "09:05:21";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000004;
    	row["Log Date"] = "2014/10/01";
    	row["Type"] = "F2";
    	row["Time"] = "00:07:09";
    	 
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000004;
    	row["Log Date"] = "2014/10/01";
    	row["Type"] = "F1";
    	row["Time"] = "15:46:49";
    	dv.Rows.Add(row);
    	
    	row = dv.NewRow();
    	row["User ID"] = 0000000004;
    	row["Log Date"] = "2014/10/02";
    	row["Type"] = "F2";
    	row["Time"] = "00:09:52 ";
    	dv.Rows.Add(row);
    	
    	foreach(var personGrouping in dv.Rows.Cast<DataRow>().GroupBy(r => r.Field<int>("User ID")))
    	{
    		foreach(var dayGrouping in personGrouping.GroupBy(r => r.Field<string>("Log Date")))
    		{
    			//Now we need to find F1 and F2
    			var orderedTime = dayGrouping.OrderBy(dg => dg.Field<string>("Time")).ToList();
    			for (var i = 0; i < orderedTime.Count; i++)
    			{
    				
    				var f1 = orderedTime[i];
    				if (orderedTime.Count <= i + 1) //Either F2 doesn't exist, or it exists on another date
    					continue;
    				
    				var f2 = orderedTime[i + 1];
    				
    				if (!overtime.Rows.Cast<DataRow>().Any (dr => dr.Field<int>("ID") == personGrouping.Key && dr.Field<string>("Log Date") == dayGrouping.Key))
    				{
    					row = overtime.NewRow();
    					row["ID"] = personGrouping.Key;
    					row["Log Date"] = dayGrouping.Key;
    					row["F1"] = f1.Field<string>("Time");
    					row["F2"] = f2.Field<string>("Time");
    					overtime.Rows.Add(row);
    
    				}
    				
    			}
    			
    		}
    	}
    	
    	overtime.Dump();
    }
