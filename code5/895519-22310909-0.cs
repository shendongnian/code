    Task.Factory.StartNew(()=>
					{
						return CheckConflict(startDate, endDate, actID, repeatRule,whichTime);
					}).ContinueWith(x=>
						{
							GetConflictDelegate(whichTime);
						},TaskScheduler.FromCurrentSynchronizationContext());
