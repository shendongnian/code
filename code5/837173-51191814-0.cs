	void Main()
	{
		T[] Push<T>(ref T[] ar, params T[] items) 
		{ 
				var tmp = ar.ToList(); Array.ForEach(items, f => tmp.Add(f)); 
				ar = tmp.ToArray(); return ar; 
		}
		T Pop<T>(ref T[] ar) 
		{ 
				T item = default(T); 
				if (ar.Length > 0) 
				{ 
						var tmp = ar.ToList(); item = tmp.LastOrDefault(); 				
						Array.Resize(ref ar, ar.Length - 1);
				}; 
				return item; 
		}	
		
       // Example: Create an array
	   var arr = new[] { 1, 2, 3, 4 };
       // Push 5, 6, 7 to the end
	   Push(ref arr, 5, 6, 7).Dump();
	
       // Pop the last element (7)
	   Pop(ref arr).Dump(); arr.Dump();
	}
