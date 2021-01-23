	return Fluently.Configure()
	.Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey(Stale.NazwaPolaczeniaERP)).DefaultSchema("dbo"))
	.Mappings(m =>
	{
		var model = AutoMap.Assemblies(new AutomappingConfiguration(),
		new Assembly[]
		{
			typeof(ERP.DomenaERP.ZnacznikZasobu).Assembly
		});
		model.Conventions.Add(new SetEnumTypeConvention());
		model.Conventions.Add(new ColumnConvention());
		model.Conventions.Add(new CollectionAccessConvention());
		model.Conventions.Add(new OptimisticLockIgnoreConvention());
		model.Conventions.Add(new SqlTimestampConvention());
		model.Conventions.Add(new SetTableNameConvention());
		model.Conventions.Add(new VersionConvention());
		model.Conventions.Add(new HasManyConvention());
		model.Conventions.Add(new InheritanceConvention());
		model.Conventions.Add(new ColumnNameConvention());
		model.Conventions.Add(DefaultLazy.Always());
		m.AutoMappings.Add(model);
	})
