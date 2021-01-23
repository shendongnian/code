    public class FooSerialzer : IBsonSerializer
        {
            public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
            {
                return BsonSerializer.Deserialize<Foo>(bsonReader);
            }
    
            public object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
            {
                throw new NotImplementedException();
            }
    
            public IBsonSerializationOptions GetDefaultSerializationOptions()
            {
                throw new NotImplementedException();
            }
    
            public void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
            {
               ......
            }
        }
