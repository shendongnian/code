	public static IEnumerable<TasCriteria> EnumerateTasCriteria(DataTable table)
	{
		return 
			(from c in table.AsEnumerable()
			select new TasCriteria()
			{
				TasCriteriaId = Convert.ToInt32(c["TasCriteriaId"]),
				TasCriteriaDesc= c["CriteriaDesc"].ToString()
			}).ToList<TasCriteria>();
	}
	public static IEnumerable<DetailCriteria> EnumerateDetailCriteriaCriteria(
                                                DataTable table)
	{
		return 
			(from c in table.AsEnumerable()
			 select new DetailCriteria()
			{
			DetailCriteriaId = Convert.ToInt32(c["DetailCriteriaId"]),
			DetailCriteriaDesc = c["CriteriaDesc"].ToString()
			}).ToList<TasCriteria>();
	}
