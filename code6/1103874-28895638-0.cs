    var a = new int[]{2, 3, 4, 3, 4, 2, 4, 2, 4};
    var b = new int[a.Length];
		
		var aAsList = a.ToList();
		
		for (var i = 0;i < b.Length; i++)
		{
			var result = aAsList.Count(x=> x == i);
			b[i] = result;
			
			if (result != 0)
			{
				Console.WriteLine(string.Format("b[{0}] : {1}",i,result));
			}
		}		
