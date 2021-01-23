	(from _obj1 in table1.Where(p => p.IsActive == true))
	   from prob in table2.Where(p => (p.Id == _obj1.Id && !p.IsBlocked && p.IsActive && p.ConditionVariable == 0)
								   || (p.ConditionVariable > 0 && p.Id == p.ConditionVariable && !p.IsBlocked && p.IsActive))
	   select new Class1
	   {
		   Title = prob.Title,
		   Status = prob.IsPending,
		   Id = obj1.id 
	   }
