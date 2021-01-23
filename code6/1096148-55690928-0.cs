c#
public class NoDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName => null;
        public Type GetActualType(IBsonReader bsonReader, Type nominalType) => nominalType;
        public BsonValue GetDiscriminator(Type nominalType, Type actualType) => null;
    }
and register it:
c#
BsonSerializer.RegisterDiscriminatorConvention(typeof(BaseEntity), new NoDiscriminatorConvention());
