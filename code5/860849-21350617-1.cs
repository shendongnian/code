    public class PolymorphicProductConverter: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProductBase);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            ProductBase product;
            var pt = obj["productType"];
            if (pt == null)
            {
                throw new ArgumentException("Missing productType", "productType");
            }
            string productType = pt.Value<string>();
            if (productType == "concrete1")
            {
                product = new ConcreteProduct1();
            }
            else if (productType == "concrete2")
            {
                product = new ConcreteProduct2();
            }
            else
            {
                throw new NotSupportedException("Unknown product type: " + productType);
            }
            serializer.Populate(obj.CreateReader(), product);
            return product;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
