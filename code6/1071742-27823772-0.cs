    public class TestSerialzer : IBsonSerializer
    {
        public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
        {
            return BsonSerializer.Deserialize<Test>(bsonReader);
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
            var test = (Test)value;
            bsonWriter.WriteStartDocument();
            if (string.IsNullOrEmpty(test.Id)) test.Id = ObjectId.GenerateNewId().ToString();
            bsonWriter.WriteString("_id", test.Id);
            foreach (var nestedObj in test.SubTestList)
            {
                if (string.IsNullOrEmpty(nestedObj.Id)) nestedObj.Id = ObjectId.GenerateNewId().ToString();
            }
            bsonWriter.WriteStartArray("SubTestList");
            BsonSerializer.Serialize(bsonWriter, test.SubTestList);
            bsonWriter.WriteEndArray();
            bsonWriter.WriteEndDocument();
        }
    }
