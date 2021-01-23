    public void DoSearch(MyViewModel vm)
	{
		Expression<Func<Customer, bool>> myFilter = x => yourCurrentFilterLogic;
		var combined = myFilter.And(x => x.GroupId == vm.GroupId);	 //PredicateBuilder extension method
		var customers = Get(combined);
	}
	
	public Customer Get(Expression<Func<Customer, bool>> where)
	{
		return customerRepository.Get(where);
	}
