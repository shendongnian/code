    public class SubBusinessDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName
        {
            get { return "subBusinessName"; }
        }
        public Type GetActualType(BsonReader bsonReader, Type nominalType)
        {
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            var actualType = nominalType;
            if (bsonReader.FindElement(ElementName))
            {
                var discriminator = (BsonValue)BsonValueSerializer.Instance.Deserialize(bsonReader, typeof(BsonValue), null);
                actualType = BsonSerializer.LookupActualType(nominalType, discriminator);
            }
            bsonReader.ReturnToBookmark(bookmark);
            return actualType;
        }
        public BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            var classMap = BsonClassMap.LookupClassMap(actualType);
            return classMap.Discriminator;
        }
    }
