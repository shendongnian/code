	void Main()
	{
		BsonSerializer.RegisterSerializationProvider(new MyDecimalSerializer());
		Console.WriteLine(new Test().ToJson(new JsonWriterSettings() { Indent = true }));
	}
	class MyDecimalSerializer : DecimalSerializer, IBsonSerializationProvider {
		private IBsonSerializationOptions _defaultSerializationOptions = new RepresentationSerializationOptions(BsonType.Double);
        public override void Serialize(
            BsonWriter bsonWriter,
            Type nominalType,
            object value,
            IBsonSerializationOptions options) {
			if(options == null) options = _defaultSerializationOptions;
			base.Serialize(bsonWriter, nominalType, value, options);
		}
		
        public IBsonSerializer GetSerializer(Type type) {
			return type == typeof(Decimal) ? this : null;
		}
	}
