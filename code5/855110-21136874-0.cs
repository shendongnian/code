	var strSort = "Name";
	
	var query = objListOrder;
	if(strSort == "OrderDate")
		query = query.OrderBy(o=>o.OrderDate);
	else if(strSort == "Name")
		query = query.OrderBy(o=>o.Name);
	else if(strSort == "Amount")
		query = query.OrderBy(o=>o.Amount);
		
	List<Order> SortedList = query.ToList();
