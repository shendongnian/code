	public static Expression<Func<Customer, T>> GetGroupClause(int groupID)
	{
		return PredicateBuilder.True<Customer>().And(x => x.Id == groupID);	
	}
	var customers = Repo.Get(myCondition).Where(GetGroupClause(myGroupID));
