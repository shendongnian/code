    public class MyIMongoSerializer : SerializerBase<IMongoQuery>
    {
        public override void Serialize(BsonSerializationContext context,
                                       BsonSerializationArgs args,
                                       IMongoQuery value)
        {
            if (value == null)
            {
                context.Writer.WriteNull();
            }
            else
            {
                var query = (IMongoQuery)value;
                var json = query.ToJson();
                context.Writer.WriteString(json);
            }
        }
        public override IMongoQuery Deserialize(BsonDeserializationContext context,
                                                BsonDeserializationArgs args)
        {
            if (context.Reader.GetCurrentBsonType() == BsonType.Null)
            {
                context.Reader.ReadNull();
                return null;
            }
            else
            {
                var value = context.Reader.ReadString();
                var doc = BsonDocument.Parse(value);
                var query = new QueryDocument(doc);
                return query;
            }
        }
    }
