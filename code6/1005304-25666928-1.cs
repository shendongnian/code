        public virtual WriteConcernResult Save(Type nominalType, object document, MongoInsertOptions options)
        {
            if (nominalType == null)
            {
                throw new ArgumentNullException("nominalType");
            }
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            var serializer = BsonSerializer.LookupSerializer(document.GetType());
