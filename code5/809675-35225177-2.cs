    public class DiscriminatorConvention<T> : IDiscriminatorConvention
    {
        public string ElementName => "_t";
        public Type GetActualType(IBsonReader bsonReader, Type nominalType)
        {
            if (!typeof(T).IsAssignableFrom(nominalType))
                    throw new Exception($"Cannot use DiscriminatorConvention<{typeof(T).Name}> for type " + nominalType);
            var ret = nominalType;
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            if (bsonReader.FindElement(ElementName))
            {
                var value = bsonReader.ReadString();
                ret = Type.GetType(value);
                
                if (ret == null)
                    throw new Exception("Could not find type from " + value);
                if (!typeof(T).IsAssignableFrom(ret) && !ret.IsSubclassOf(typeof(T)))
                    throw new Exception("type is not an IRestriction");
            }
            bsonReader.ReturnToBookmark(bookmark);
            return ret;
        }
        public BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            if (nominalType != typeof(Setting))
                throw new Exception($"Cannot use {GetType().Name} for type " + nominalType);
            return actualType.AssemblyQualifiedName; // ok to use since assembly version is ignored when deserialized
        }
    }
