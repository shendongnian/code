    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace DataTableJoin
    {
    	class Program
    	{
    		class StdCode
    		{
    			public string STDCode { get; set; }
    			public string Description { get; set; }
    		}
    		static void Main(string[] args)
    		{
    			DataTable dt = new DataTable();
    			DataColumn dc = new DataColumn();
    			dt.Columns.Add(new DataColumn("Code"));
    			dt.Columns.Add(new DataColumn("Value"));
    			dt.Columns.Add(new DataColumn("STDCode"));
    			dt.Columns.Add(new DataColumn("Description"));
    
    			DataRow row = dt.NewRow();
    			row["Code"] = "code1";
    			row["Value"] = "value1";
    			row["STDCode"] = "abcd12";
    			row["Description"] = "abcjkdh";
    			dt.Rows.Add(row);
    
    			row = dt.NewRow();
    			row["Code"] = "code2";
    			row["Value"] = "value2";
    			row["STDCode"] = "cdfg34";
    			row["Description"] = "cdfg34";
    			dt.Rows.Add(row);
    
    			List<StdCode> listCodes = new List<StdCode>()
    			{
    				new StdCode(){ STDCode = "abcd12", Description="sdfsd"},
    				new StdCode(){ STDCode="fhry67", Description = "uisydif"}
    			};
    
    
    			var query = dt.AsEnumerable().
    									Select(item => new
    									{
    										Code = item.Field<string>("Code"),
    										Value = item.Field<string>("Value"),
    										STDCode = item.Field<string>("STDCode"),
    										Description = item.Field<string>("Description")
    									});
    
    			var query1 = listCodes.Join(query, x => x.STDCode, y => y.STDCode, (x, y) => y);
    
    			Console.WriteLine("Code\tValue\tSTDCode\tDescription");
    			foreach (var r in query1)
    			{
    				Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", r.Code , r.Value , r.STDCode , r.Description));
    			}
    		}
    	}
    }
