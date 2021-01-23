    if(testPlans.Where(plan =>  startDate >= plan.p_startDateTime && endDate <= plan.p_endDateTime).Count() > 0)
				{
					return false;
				}
				else
				{
					if(testPlans.Where(plan =>  startDate > plan.p_startDateTime && startDate < plan.p_endDateTime).Count() > 0)
					{
						return false;
					}
					else
					{
						if(testPlans.Where(plan =>  endDate > plan.p_startDateTime && endDate < plan.p_endDateTime).Count() > 0)
						{
							return false;
						}
						else
						{
							return true;
						}
					}
				}
