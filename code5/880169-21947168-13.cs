    using BaseCollection = System.Collections.Generic.ICollection<JsonContractandConvert.Models.Role>;
    public class RemoveAccountsFromRolesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseCollection).IsAssignableFrom(objectType);
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
            if (!this.CanConvert(value.GetType())) return;
    
            var entities = value as BaseCollection;
            if (entities == null) return;
    
            writer.WriteStartArray();
            foreach (var entity in entities)
            {
            entity.Accounts = null;
            serializer.Serialize(writer, entity);
            }
            writer.WriteEndArray();
        }
    }
