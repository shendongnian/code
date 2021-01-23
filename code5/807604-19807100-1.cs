        var Group = dt.AsEnumerable().GroupBy(x => x["CustomerLocation"].ToString()).ToDictionary(x => x.Key, x => x.ToList());
    
        foreach (var Items in Group)
        {
            foreach (var DistinctCustomerID in Items.Value.Select(x => x["CustomerID"].ToString()).Distinct())
    {
                // Gets first instance only
    	        var Instance = dt.AsEnumerable().Where(x => x[DistinctCustomerID] == DistinctCustomerID).FirstOrDefault();
    
                int SumCustomerDebt = Convert.ToInt32(Instance["CustomerDebt"].ToString());
    
    	        var Customer = new { CustomerLocation = Items.Key, SumSubTotal = Instance["SumSubTotal"].ToString(), OrderCount = Instance["OrderCount"].ToString(), SumCustomerDebt = SumCustomerDebt };
    
    	        Console.WriteLine("You can Print Customer object's Properties");
            }
        }
