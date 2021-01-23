    using System;
    using System.Collections.Generic;
    using System.Data;		
    using System.Xml.Serialization;
    using System.Linq;
    using System.Data.Linq;
    using System.Data.DataSetExtensions;
    
    public class Program
    {
    	public static void Main()
    	{
    		using (DataTable dt = new DataTable("MyDataTable"))
    		{
    			// Add two columns.
    			dt.Columns.Add("Id", typeof(int));
    			dt.Columns.Add("Name", typeof(string));			
    			
    			// Add some test data.
    			Random rnd = new Random();
    			for(int i = 0; i < 7; i++)
    			{
    				DataRow dr = dt.NewRow();
    				dr["Id"] = rnd.Next(1, 4);
    				dr["Name"] = "Row-" + (i + 1);
    				dt.Rows.Add(dr);
    			}
    			
    			Console.WriteLine("All rows:");
    			PrintResults(dt.AsEnumerable());
    			
    			var results = dt
                    .AsEnumerable()
                    .GroupBy(x => (int)x["Id"])
                    .Select(g => g.First());
    			
    			Console.WriteLine("Distinct rows:");
    			PrintResults(results);
    		}
    	}
    	
    	private static void PrintResults(IEnumerable<DataRow> rows)
    	{
    		foreach(var row in rows)
    		{
    			Console.WriteLine(
                    String.Format(
                        "Id: {0}, Name: {1}", 
                        (int)row["Id"], 
                        (string)row["Name"]));
    		}	
    	}
    }
