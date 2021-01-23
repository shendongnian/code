	public List<TEntity> GetReferenceWithPredefinedItem<TEntity>(DbSet<TEntity> dbset) where TEntity : class, new(), IReference
	{
		var data = from a in dbset
				   orderby a.Title
				   select a;
		var	list = data.ToList();
		list.Insert(0, new TEntity() { Id = -1, Title ="aefaef" });
		return list;
	}
