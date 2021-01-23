    class IRestrictionDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName
        {
            get { return "_t"; }
        }
        public Type GetActualType(BsonReader bsonReader, Type nominalType)
        {
            //Edit: added additional check for list
            if (nominalType != typeof(IRestriction) && nominalType != typeof(List<IRestriction>))
                throw new Exception("Cannot use IRestrictionDiscriminatorConvention for type " + nominalType);
            var ret = nominalType;
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            if (bsonReader.FindElement(ElementName))
            {
                var value = bsonReader.ReadString();
                ret = Type.GetType(value);
                if (ret == null)
                    throw new Exception("Could not find type from " + value);
                //Edit: doing the checking a little different
                if (!typeof(IRestriction).IsAssignableFrom(ret) && !ret.IsSubclassOf(typeof(IRestriction)))
                    throw new Exception("type is not an IRestriction");
            }
            bsonReader.ReturnToBookmark(bookmark);
            return ret;
        }
        public BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            if (nominalType != typeof(IRestriction) && nominalType != typeof(List<IRestriction>))
                throw new Exception("Cannot use FooDiscriminator for type " + nominalType);
            /*Edit: had to change this because we were getting Unknown discriminator value 
           'PackNet.Common.Interfaces.RescrictionsAndCapabilities.BasicRestriction`1[[System.String, ... */
            return actualType.AssemblyQualifiedName;
        }
    }
