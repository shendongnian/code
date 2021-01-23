	(from _obj1 in table1.Where(p => p.IsActive == true))
	   from prob in table2.Where(p => {
				bool state = false;
				if(p.ConditionVariable > 0)  {
					state = p.Id == p.ConditionVariable && !p.IsBlocked && p.IsActive;
				} else if(p.ConditionVariable == 0) {
					state = p.Id == _obj1.Id && !p.IsBlocked && p.IsActive;
				}
				return state;	
			})
	   select new Class1
	   {
		   Title = prob.Title,
		   Status = prob.IsPending,
		   Id = _obj1.id 
	   }
