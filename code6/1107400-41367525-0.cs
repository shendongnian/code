    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public class Item
		{
			public int Id { get; set; }	
		}
		
		public static void Main()
		{
			var oldList = new List<Item>();
			
			oldList.Add(new Item() { Id = 3 });
			oldList.Add(new Item() { Id = 4 });
			oldList.Add(new Item() { Id = 5 });
			
			var newList = new List<Item>();
			
			newList.Add(new Item() { Id = 1 });
			newList.Add(new Item() { Id = 2 });
			newList.Add(new Item() { Id = 3 });
			
            // here is the linq join
			var result = 
                newList.Join(
                    oldList, 
                    item => item.Id, 
                    item => item.Id, 
                    (itemNew, itemOld) => itemNew).FirstOrDefault();
			
            // outputs 3
			Console.WriteLine(result.Id);
		}
	}
