    public TableAMap()
	{
		Table("TableA");
		Id(x=> x.Id).GeneratedBy.Assigned();
		Map(x=> x.Name).Not.Nullable();
		References(x => x.TableB, TableBId);
	}
	
	public TableBMap()
	{		
		Table("TableB");
		Id(x=> x.Id).GeneratedBy.Assigned();
		Map(x=> x.Amount).Not.Nullable();
		HasMany<TableA>(x => x.TableA)
		.Nullable()
        .KeyColumn("TableAId");
	}
