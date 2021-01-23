	//there is no function or procedure in c#;
	//function List<CustomObject2> GetDataPoint(List<CustomObject> listDataPoints)
	List<CustomObject2> GetDataPoint(List<CustomObject> listDataPoints)
	{
		var dataPoints = listDataPoints.Where(r => r != null);
		
		if (dataPoints.Empty())
			//return; you cant not return anything in a function
			return null; //or return an empty list
			//return new List<CustomObject2>();
	
		
		var cObjList = dataPoints.Aggregate(
			new Stack<CustomObject>(),
			(results, r) =>
			{	
				if (r.GetDistance(results.Peek()) > 100)
					results.Add(r);
				return results;
			})
			.Select(r => new CustomObject2(){ Var1 = r.Var1 })
			.ToList();
		
		//return directly the line above or do more work with cObjList...
	}
