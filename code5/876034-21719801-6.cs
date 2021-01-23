	public DataTable MergeShippingData(DataTable groupTable, DataTable detailTable)
	{
		// convert group table to array of GroupEntry objects
		var groupList = 
			(
				from DataRow grouprow in groupTable.Rows
				let ent = GroupEntry.FromRow(grouprow)
				where ent != null
				select ent
			).ToArray();
		
		// convert detail table to sequence of DetailEntry objects
		var detailSeq = 
				from DataRow detailrow in detailTable.Rows
				let ent = DetailEntry.FromRow(detailrow)
				where ent != null
				select ent;
		
		// Create output DataTable
		DataTable output = CreateOutputTable();
	
		// Process all detail lines into shippings
		foreach (var detail in detailSeq)
		{
			// Find available shipping group for the item code with enough remaining capacity
			var grp = groupList.First (g => g.ItemCode == detail.ItemCode && g.Remainder >= detail.Quantity);
			if (grp == null)
				throw new Exception("No available shipping found for detail item...");
			
			// update remaining space in shipping group
			grp.Remainder -= detail.Quantity;
			
			// add data to output table
			output.Rows.Add(new object[] {
					grp.Shipment, grp.Line, grp.Remarks, grp.ItemCode, grp.TotalQty,
					detail.RefNo, detail.Quantity, detail.Weight, detail.From				
				});
		}
		
		return output;
	}
	
	// Class to hold the shipping groups while processing
	public class GroupEntry
	{
		// fields from source DataTable
		public string ItemCode;
		public int TotalQty;
		public string Shipment;
		public string Remarks;
		public int Line;
		
		// process variable, holds remaining quantity value
		public int Remainder;
		
		// Convert DataRow into GroupEntry
		public static GroupEntry FromRow(DataRow r)
		{
			try 
			{
				return new GroupEntry
				{
					ItemCode = r.Field<string>(0),
					TotalQty = r.Field<int>(1),
					Shipment = r.Field<string>(2),
					Remarks = r.Field<string>(3),
					Line = r.Field<int>(4),
					Remainder = r.Field<int>(1)
				};
			}
			catch { }
			return null;
		}
	}
	
	// Class to hold shipping Detail records during processing
	public class DetailEntry
	{
		public string RefNo;
		public string ItemCode;
		public int Quantity;
		public int Weight;
		public string From;
		
		// Convert DataRow into DetailEntry
		public static DetailEntry FromRow(DataRow r)
		{
			try
			{
				return new DetailEntry
				{
					RefNo = r.Field<string>(0),
					ItemCode = r.Field<string>(1),
					Quantity = r.Field<int>(2),
					Weight = r.Field<int>(3),
					From = r.Field<string>(4)
				};
			}
			catch { }
			return null;
		}
	}
	
	// Create output DataTable
	public DataTable CreateOutputTable()
	{
		DataTable res = new DataTable();
		res.Columns.Add("Shipment", typeof(string));
		res.Columns.Add("Line", typeof(Int32));
		res.Columns.Add("Remarks", typeof(string));
		res.Columns.Add("ItemCode", typeof(string));
		res.Columns.Add("TotalQty", typeof(Int32));
		res.Columns.Add("RefNo", typeof(string));
		res.Columns.Add("Quantity", typeof(Int32));
		res.Columns.Add("Weight", typeof(Int32));
		res.Columns.Add("From", typeof(string));
	
		return res;
	}
