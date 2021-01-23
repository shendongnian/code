        internal class DecimalConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(decimal) || objectType == typeof(decimal?));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                Decimal? d = default(Decimal?);
                if (value != null)
                {
                    d = value as Decimal?;
                    if (d.HasValue) // If value was a decimal?, then this is possible
                    {
                        d = new Decimal?(new Decimal(Decimal.ToDouble(d.Value))); // The ToDouble-conversion removes all unnessecary precision
                    }
                }
                JToken.FromObject(d).WriteTo(writer);
            }
        }
