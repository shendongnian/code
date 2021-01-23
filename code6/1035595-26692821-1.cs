    var cycleNum = 2;
    
    var curCycleCars = LstCyclces[cycleNum - 1].Cars;
    var prevCycleCars = LstCyclces[cycleNum - 2].Cars;
    
    var cars = curCycleCars.Join(prevCycleCars, 
    					p => p.CarId, 
    					y => y.CarId,
    					(f1, f2) => new { 
    							Car = f1,
    							Distance = f1.Location - f2.Location
    						})
    					.Where(c => c.Distance < 40)
    					.Select(c => c.Car)
    					.OrderBy(car => car.Location)
    					.ToList();
    					
    					
    	
    var carPairs = new CarPairList[cars.Count()];
    
    for(var i = 0; i < cars.Count; i++)
    {
    	var curCar = cars[i];
    	var curStartIndex = i + 1;
    
    	if(i > 0)
    	{
    		var previousCarPair = carPairs[i - 1];
    		if(previousCarPair!=null)
    		{
    			curStartIndex = previousCarPair.EndIndex;
    		}
    	}
    	
    	int j;
    	for(j = curStartIndex; j < cars.Count; j++)
    	{
    		var dis = cars[j].Location - curCar.Location;
    		if(dis >= 65) break;
    	}
    	
    	var startIndex = i + 1;
    	var endIndex = j - 1;
    	
    	if(endIndex >= startIndex)
    	{
    		carPairs[i] = new CarPairList(curCar, 
    							startIndex, endIndex);
    	}
    }
    
    foreach(var carPair in carPairs.Where(x => x!=null)){
    	Console.WriteLine("Car " + carPair.Car.CarId);
    	Console.WriteLine("Cars near the distance: ");
    	
    	for(var i = carPair.StartIndex; i <= carPair.EndIndex; i++){
    		Console.WriteLine("\t - {0}, distance {1}", 
    			cars[i].CarId,
    			cars[i].Location - carPair.Car.Location);
    	}
    	
    	Console.WriteLine();
    }
    
    class CarPairList
    {
    	public readonly Car Car;
    	public readonly int StartIndex;
    	public readonly int EndIndex;
    	
    	public CarPairList(Car car, 
    		int startIndex,
    		int endIndex){
    		Car = car;
    		StartIndex = startIndex;
    		EndIndex = endIndex;
    	}
    }
