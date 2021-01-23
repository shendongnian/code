	var conventions = new ConventionPack();
	var representAsDouble = new RepresentationSerializationOptions(BsonType.Double);
	var representArrayAsDouble = new ArraySerializationOptions(representAsDouble);
	var representDictionaryAsDouble = new DictionarySerializationOptions(){ KeyValuePairSerializationOptions = new KeyValuePairSerializationOptions() { ValueSerializationOptions = representArrayAsDouble}};
	conventions.Add(new MemberSerializationOptionsConvention(typeof(decimal), representAsDouble));
	conventions.Add(new MemberSerializationOptionsConvention(typeof(decimal[]), representArrayAsDouble));
	conventions.Add(new MemberSerializationOptionsConvention(typeof(Dictionary<string, decimal[]>), representDictionaryAsDouble));
	conventions.Add(new MemberSerializationOptionsConvention(typeof(SortedDictionary<string, decimal[]>), representDictionaryAsDouble));
	ConventionRegistry.Register("Serialize decimal as double", conventions, t => true);
