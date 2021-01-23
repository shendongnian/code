    public class TransactionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Transaction).IsAssignableFrom(objectType);
        }
    
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken transaction = JToken.Load(reader)["transaction"];
            if (transaction["recipient"] != null)
            {
                return transaction.ToObject<InternalTransaction>();
            }
            else
            {
                return transaction.ToObject<ExternalTransaction>();
            }
        }
    
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
