	var conventions = new ConventionPack
	{
		new DecimalRepresentationConvention(BsonType.Double)
	};
	ConventionRegistry.Register("decimalAsDouble", conventions, t => condition);
