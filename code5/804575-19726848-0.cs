    static ResultHeader<Customer> AdaptResult(
                             ResultHeader<Dictionary<string, string>> tmp)
    {
    	var res = new ResultHeader<Customer>();
    	res.Success = tmp.Success;
    	res.Total = tmp.Total;
    	res.List = new List<Customer>();
    	foreach (var el in tmp.List)
    	{
    		var cust = new Customer();
    		cust.Firstname = el["Firstname"];
    		cust.RemainingItems = 
    			el.Where(x => x.Key != "Firstname")
    			  .ToDictionary(x => x.Key, x => x.Value);
    		res.List.Add(cust);
    	}
    	return res;
    }
   
