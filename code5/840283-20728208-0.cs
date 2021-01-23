    using System;
    using System.Collections.Generic;
    using System.Linq;
    
        public class MyData
        {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int Floor { get; set; }
    }
    
    public class MyGroupedData
    {
    	public string Name { get; set; }
    	public IEnumerable<int> Floors { get; set; }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		MyData[] data = { 
    			new MyData() { Id = 1, Name = "Store1", Floor = 1 }, 
    			new MyData() { Id = 2, Name = "Store2", Floor = 1 }, 
    			new MyData() { Id = 3, Name = "Store2", Floor = 2 }, 
    			new MyData() { Id = 4, Name = "Store2", Floor = 3 }, 
    			new MyData() { Id = 5, Name = "Store3", Floor = 2 },
    		};
    		var groupedData = from x in data group x by x.Name into grp 
    			select new MyGroupedData() { Name = grp.Key, Floors = grp.Select(y => y.Floor) };
    		foreach(var g in groupedData)
    			Console.WriteLine("{0} -> {1}", g.Name, string.Join(", ", g.Floors.Select(x => x.ToString()).ToArray()));
    	}
    }
