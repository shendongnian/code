    public sealed class StringOrInt32Serializer : BsonBaseSerializer
    {
        public override object Deserialize(BsonReader bsonReader, Type nominalType,
            Type actualType, IBsonSerializationOptions options)
        {
            var bsonType = bsonReader.CurrentBsonType;
            switch (bsonType)
            {
                case BsonType.Null:
                    bsonReader.ReadNull();
                    return null;
                case BsonType.String:
                    return bsonReader.ReadString();
                case BsonType.Int32:
                    return bsonReader.ReadInt32().ToString(CultureInfo.InvariantCulture);
                default:
                    var message = string.Format("Cannot deserialize BsonString or BsonInt32 from BsonType {0}.", bsonType);
                    throw new BsonSerializationException(message);
            }
        }
    
        public override void Serialize(BsonWriter bsonWriter, Type nominalType,
            object value, IBsonSerializationOptions options)
        {
            if (value != null)
            {
                bsonWriter.WriteString(value.ToString());
            }
            else
            {
                bsonWriter.WriteNull();
            }
        }
    }
