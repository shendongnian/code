	List<MyClassData> mData = (from t in db.MydbProcedure(temp)
								select new MyClassData
								{
									Id = t.Id,
									ParentId = t.ParentId,
									Title = t.Title
								})
		.OrderBy(it => it.Id)
		.GroupBy(it => it.Title)
		.Where(b => b != null)
		.SelectMany(it => it)
		.ToList();
