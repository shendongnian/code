    public class TrackableCollectionConverter<TEntity, TDeserialiseType> : JsonConverter where TEntity: ITrackableEntity
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType == typeof(TrackableCollectionCollection<ITrackableEntity>);
        }
        public override object ReadJson(
            JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            // N.B. null handling is missing
            var surrogate = serializer.Deserialize<TDeserialiseType>(reader) as TrackableCollectionCollection<TEntity>;
            var trackablecollection = new TrackableCollectionCollection<TEntity>();
            foreach (var el in surrogate)
                trackablecollection.Add(el);
            foreach (var el in surrogate.NewItems)
                trackablecollection.NewItems.Add(el);
            foreach (var el in surrogate.ModifiedItems)
                trackablecollection.ModifiedItems.Add(el);
            foreach (var el in surrogate.DeletedItems)
                trackablecollection.DeletedItems.Add(el);
            return trackablecollection;
        }
        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Serialize(writer, value);
        }
    }
