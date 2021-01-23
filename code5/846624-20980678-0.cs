	public IQueryable<MyViewModel> GetFooList(int parameter)
	{
		var query = (from x in dbContext.TableX
					 join y in dbContext.TableY on x.our_id equals y.our_id
					 join z in dbContext.TableZ on y.our_id equals z.our_id
					 join a in dbContext.TableA on z.other_id  equals a.other_id 
					 where x.their_id == parameter
					 select new MyViewModel()
					 {
						field1 = x.field1,
						field2 = y.field2,
						field3 = z.field3 //<= this field did not exist in MyType
					 }
					 ).AsQueryable();
		return query;
	}
