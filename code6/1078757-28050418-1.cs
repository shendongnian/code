    public class FooSerialzer : BsonBaseSerializer
    {
        private static readonly IBsonSerializer Serializer;
    
        static FooSerialzer()
        {
            var classMap = BsonClassMap.LookupClassMap(typeof(Foo));
            var serializerType = Type.GetType("MongoDB.Bson.Serialization.BsonClassMapSerializer, MongoDB.Bson", true);
            Serializer = (IBsonSerializer)Activator.CreateInstance(serializerType, classMap);
        }
    
        public override object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
        {
            var document = BsonSerializer.Deserialize<BsonDocument>(bsonReader);
            var foo = (Foo)Serializer.Deserialize(BsonReader.Create(document), typeof(Foo), options);
     
            // do your customization for foo here
            return foo;
        }
    
        public override void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
        {
            var foo = (Foo) value;
            foo.Id = ObjectId.GenerateNewId().ToString();
    
            var document = new BsonDocument();
            Serializer.Serialize(BsonWriter.Create(document), nominalType, value, options);
    
            BsonSerializer.Serialize(bsonWriter, document);
        }
    }
