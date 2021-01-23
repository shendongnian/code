    public class BSerialzer : IBsonSerializer
    {
        public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
        {
            throw new NotImplementedException();
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
            var b = (B)value;
            bsonWriter.WriteStartDocument();
    
            bsonWriter.WriteString("_id", b.Id);            
            bsonWriter.WriteStartArray("refs");
            foreach (var refobj in b.ReferredAObjects)
            {
                bsonWriter.WriteString(refobj.Id);
            }
            bsonWriter.WriteEndArray();            
    
            bsonWriter.WriteEndDocument();
        }
    }
