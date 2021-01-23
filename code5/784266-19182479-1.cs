	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	class DrawingData {
		public string DrawingName{get;set;} 
		public int DrawingQty {get;set;}
	}
	
	class DrawingDataComparer : IEqualityComparer<DrawingData>
	{
	
	    public bool Equals(DrawingData d1, DrawingData d2)
	    {
	        return d1.DrawingName.Equals(d2.DrawingName);
	    }
	
	
	    public int GetHashCode(DrawingData d)
	    {
	        return d.DrawingName.GetHashCode();
	    }
	
	}
	
	public class Test
	{
		public static void Main()
		{
			List<DrawingData> _DrawingList = new List<DrawingData>();
			_DrawingList.Add(new DrawingData() { DrawingName = "411000D", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000D", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000A", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000A", DrawingQty = 1 });        
			_DrawingList.Add(new DrawingData() { DrawingName = "411000C", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000C", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000B", DrawingQty = 1 });
			_DrawingList.Add(new DrawingData() { DrawingName = "411000B", DrawingQty = 1 });
			
			_DrawingList = _DrawingList.OrderBy(c => c.DrawingName).ToList();
			var distinct = _DrawingList.Distinct(new DrawingDataComparer());
			var organized = distinct.Concat(_DrawingList.Except(distinct));
			foreach(DrawingData dd in organized)
				Console.WriteLine(dd.DrawingName);
		}
	}
