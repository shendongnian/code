    public class BsonDecimalSerializer : DecimalSerializer, IBsonSerializationProvider
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, decimal value)
        {
            context.Writer.WriteDouble((double)value);
        }
        public override decimal Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return (decimal)context.Reader.ReadDouble();
        }
        public IBsonSerializer GetSerializer(Type type)
        {
            return type == typeof(decimal) ? this : null;
        }
    }
