    public class PersonSerialzer : IBsonSerializer
    {
            public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
            {
                ....
            }
            public object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
            {
                ....
            }
            public IBsonSerializationOptions GetDefaultSerializationOptions()
            {
                ....
            }
            public void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
            {
                var person = (Person)value;
                bsonWriter.WriteStartDocument();
                
                bsonWriter.WriteString("name", person.name);
                //bsonWriter.WriteString("ignorable", person.ignorable); ignore for serialize
                bsonWriter.WriteEndDocument();
            }
        }
