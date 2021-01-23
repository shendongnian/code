    class FooDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName
        {
            get { return "_t"; }
        }
        public Type GetActualType(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType)
        {
            if(nominalType!=typeof(MyAbstractClass))
                throw new Exception("Cannot use FooDiscriminator for type " + nominalType);
            var ret = nominalType;
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            if (bsonReader.FindElement(ElementName))
            {
                var value = bsonReader.ReadString();
                ret = Type.GetType(value);
                if(ret==null)
                    throw new Exception("Could not find type " + value);
                if(!ret.IsSubclassOf(typeof(MyAbstractClass)))
                    throw new Exception("Database type does not inherit from MyAbstractClass.");
            }
            bsonReader.ReturnToBookmark(bookmark);
            return ret;
        }
        public BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            if (nominalType != typeof(MyAbstractClass))
                throw new Exception("Cannot use FooDiscriminator for type " + nominalType);
            return actualType.FullName;
        }
    }
