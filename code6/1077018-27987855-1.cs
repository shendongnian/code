    public IEnumerable<Car> SearchCar(string search)
    {
    	if (string.IsNullOrEmpty(search)) return Enumerable.Empty<Car>().AsEnumerable();
    	var terms = search.ToLower().Split(' ');
    	return _context.Cars
    		.Where(x => terms.All(t => 
    			x.Brand.ToLower().Contains(t) 
    			|| x.Model.ToLower().Contains(t)
    			|| x.Code.ToLower().Contains(t)));
    }
	
