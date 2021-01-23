    public class ShallowCopyCollectionConverter<TCollectionType, TCopyType> : JsonConverter
        where TCollectionType : IEnumerable<TbdEntity>
        where TCopyType : TbdEntity, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TCollectionType).IsAssignableFrom(objectType);
        }
    
        public override bool CanRead
        {
            get { return false; }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (this.CanConvert(value.GetType()) == false) return;
    
            var entities = (TCollectionType)value;
            writer.WriteStartArray();
            foreach (var entity in entities)
            {
                serializer.Serialize(writer, entity.ShallowCopy<TCopyType>()); //ShallowCopy<> is a method in the base class that all of my classes extend.
            }
            writer.WriteEndArray();
        }
    }
