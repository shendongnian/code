    public class MyEnumSerializer : StructSerializerBase<MyEnum>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, MyEnum value)
        {
            BsonSerializer.Serialize(context.Writer, value.ToString());
        }
        public override MyEnum Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return (MyEnum)Enum.Parse(args.NominalType, BsonSerializer.Deserialize<string>(context.Reader));
        }
    }
