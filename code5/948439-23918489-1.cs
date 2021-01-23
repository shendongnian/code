	public static class PowerSet
	{
		// List with no Exact Duplicates but with Permutations
		public static List<List<int>> PS =  new List<List<int>>();
		
		
		// This Method Generates the power set with No Exact Duplicates
		// and stores the values into the Property PS.
		public static List<List<int>> Generate(List<int> setList)
		{
			// Generate Base Data to use for final results
			var setSize = setList.Count();
			var basePowerSet = from m in Enumerable.Range(0, 1 << setSize)
					select
						from i in Enumerable.Range(0, setSize)
						where (m & (1 << i)) != 0 
						select setList[i];
			
			// Temporary Result Set with Duplicates
			var results = new List<List<int>>();
			
			// Step thru each set and generate list of Permutations for each
			// Power Set generated above.
			foreach( var item in basePowerSet )
			{
				var size = item.Count();
				var positions = from m in Enumerable.Range(0, size)
					select m;
					
				var lItem = item.ToList();	
				
				// If the set has 2 or more elements in the set then generate Permutations
				switch(size)
				{
					case 0:
					case 1:
						break;
					default:
						
						// Permutations generated from Linq Extension defined
						// in Method Permute()
						var posList = positions.Permute().ToList();
						
						// remove first item which is a duplicate.
						posList.RemoveAt(0);
						
						// Generate new Lists based on all possiable
						// combinations of the data in the set.
						var x = new List<List<int>>();
						foreach(var p in posList)
						{	
							var y = new List<int>();
							foreach(var v in p)
							{
								//v.Dump("xxxx");
								y.Add(lItem[v]);
							}
							
							x.Add(y);
							
							// Add New Permutation but
							// Do not add a duplicate set.
							AddNonDuplicate(x);
						}										
						break;
				}
				
				// Add to Temp Results;
				results.Add(item.ToList());
				
				// Remove Duplicates
				AddNonDuplicate(results);
			}
			
			return results;
		}
		
		
		// Custom Method used to compare values in a set to the
		// Final Result Set named PS.
		public static void AddNonDuplicate(List<List<int>> list )
		{
			//list.Dump();
			if(list.Count() == 0)
				return;
				
			foreach(var item in list)
			{
				bool found = false;
				var mySize = PS.Count();
				if(mySize <= 0)
					PS.Add(item);
				else
					foreach(var psItem in PS)
					{
						if( item.ToString2() == psItem.ToString2() )
							found = true;
					}
				
				if(!found)
					PS.Add(item);
			}
		}
	
	}
