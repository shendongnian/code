    using System;
    using System.Data;
    using System.Xml;
    using System.Data.Linq;
    using System.Data.DataSetExtensions;
    using System.Linq;
    					
    public class Program
    {
    	public void Main()
        {
    		var results = GetResults(GetTestData());
    		
    		foreach(DataColumn dc in results.Columns)
    		{
    			Console.Write("{0},", dc.ColumnName);
    		}
    		
    		Console.WriteLine();
    		
    		foreach(DataRow dr in results.Rows)
    		{
    			foreach(DataColumn dc in results.Columns)
    			{
    				Console.Write("{0},", dr[dc.ColumnName]);
    			}
    			Console.WriteLine();
    		}
        }
    	
    	private DataTable GetResults(DataSet ds) 
    	{
    		var result = (from row in ds.Tables[0].AsEnumerable()
                  let ansvarig = row.Field<string>("Ansvarig")
                  let name = row.Field<string>("Name")
                  let week = row.Field<int>("Week")
                  let tid = row.Field<double>("Tid")
                  group row by new { ansvarig, name, week } into grp
                  select new
                  {
                      Ansvarig = grp.Key.ansvarig,
    				  Name = grp.Key.name,
    				  Week = grp.Key.week,
                      Total = grp.Sum(r => r.Field<double>("Tid"))
                  }).ToList();
    		
    		var uniqueWeeks = result
    							.Select(item => new { Week = item.Week })
    							.OrderBy(x => x.Week)
    							.Distinct()
    							.ToList();
    
    		var dt = new DataTable();
    		dt.Columns.Add(new DataColumn("Ansvarig", typeof(System.String)));
    		dt.Columns.Add(new DataColumn("Name", typeof(System.String)));
    		
    		// add week columns
    		foreach(var item in uniqueWeeks)
    		{
    			Console.WriteLine("Week: {0}", item.Week);
    			dt.Columns.Add(new DataColumn(string.Format("Week {0}", item.Week), typeof(System.String)));
    		}
    		
    		// add rows
    		foreach (var item in result)
    		{
    			var foundRow = dt.AsEnumerable().FirstOrDefault(r => r.Field<string>("Ansvarig") == item.Ansvarig && r.Field<string>("Name") == item.Name);
    			if (foundRow == null)
    			{
    				var dr = dt.NewRow();
    				dr["Ansvarig"] = item.Ansvarig;
    				dr["Name"] = item.Name;
    				dr[string.Format("Week {0}", item.Week)] = item.Total;
    				dt.Rows.Add(dr);
    			}
    			else
    			{
    				foundRow[string.Format("Week {0}", item.Week)] = item.Total;
    			}
    		}
    
    		return dt;
    	}
    	
    	private DataSet GetTestData()
    	{
    		var ds = new DataSet();
    		var dt = new DataTable();
    		dt.Columns.Add(new DataColumn("Ansvarig", typeof(System.String)));
    		dt.Columns.Add(new DataColumn("Name", typeof(System.String)));
    		dt.Columns.Add(new DataColumn("Week", typeof(System.Int32)));
    		dt.Columns.Add(new DataColumn("Tid", typeof(System.Double)));
    		
    		var dr = dt.NewRow();
    		
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "John Andersson";
    		dr["Week"] = 4;
    		dr["Tid"] = 29;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "John Andersson";
    		dr["Week"] = 5;
    		dr["Tid"] = 0;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "John Andersson";
    		dr["Week"] = 5;
    		dr["Tid"] = 0;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "John Andersson";
    		dr["Week"] = 13;
    		dr["Tid"] = 8;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Anders Cameron";
    		dr["Week"] = 4;
    		dr["Tid"] = 8;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Anders Cameron";
    		dr["Week"] = 12;
    		dr["Tid"] = 11;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Steve Smith";
    		dr["Week"] = 4;
    		dr["Tid"] = 8;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Steve Smith";
    		dr["Week"] = 6;
    		dr["Tid"] = 0;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Steve Smith";
    		dr["Week"] = 6;
    		dr["Tid"] = 0;
    		
    		dt.Rows.Add(dr);
    		
    		dr = dt.NewRow();
    		dr["Ansvarig"] = "John Doe";
    		dr["Name"] = "Steve Smith";
    		dr["Week"] = 7;
    		dr["Tid"] = 0;
    	
    		dt.Rows.Add(dr);
    		
    		ds.Tables.Add(dt);
    		
    		return ds;
    	}
    }
