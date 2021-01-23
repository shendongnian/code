    var cObjList = listDataPoints.Where(r => r != null)
    	.Aggregate(Tuple.Create(startPoint, new List<CustomObject2>()), (acc, r) => {
    		if(r.GetDistance(acc.Item1)) {
    			acc.Item2.Add(new CustomObject2 { Var1 = r.Var1 });
    			return Tuple.Create(r, acc.Item2);
    		}
    		else return acc;
    	}).Item2;
