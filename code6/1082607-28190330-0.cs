    public class JsonSerializeProperty : Attribute
    {
        public string PropertyName { get; set; }
    }
    // derive from JsonConverter and override WriteJson (serialize) 
    // and ReadJson (deserialize)
    // note: i have not implemented CanConvert
    public class CustomUserSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var user = value as User;
            if(user == null)
                throw new NullReferenceException("user");
            
            var properties = user.GetType().GetProperties();
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                // get the attribute assigned to the property [JsonSerializeProperty]
                object customAttributes = property.GetCustomAttributes(typeof(JsonSerializeProperty), false).SingleOrDefault();
                JsonSerializeProperty attribute = customAttributes as JsonSerializeProperty;
                if(attribute != null)
                {
                    // JsonSerializeProperty 
                    string propertyName = attribute.PropertyName;
                   
                    // just write new property name and value
                    writer.WritePropertyName(propertyName);
                    writer.WriteValue(property.GetValue(value, new object[] {}));
                }
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // just map every JProperty from the Json string to the  
            // JsonProperty of the user class. I know this is kind of ugly... but it may serve your purpose
            JObject jsonObject = JObject.Load(reader);
            List<JProperty> properties = jsonObject.Properties().ToList();
            // create an instance of User to assign the values of the
            // Json string 
            object instance = Activator.CreateInstance(objectType);
        
            // loop through the user properties and get the 
            // JsonProperty customattribute. then set the value of the JProperty
            PropertyInfo[] objectProperties = objectType.GetProperties();
            foreach (var objectProperty in objectProperties)
            {
                var customAttribute = objectProperty.GetCustomAttributes(typeof(JsonPropertyAttribute), false).SingleOrDefault();
                JsonPropertyAttribute attribute = customAttribute as JsonPropertyAttribute;
                if (attribute != null)
                {
                    JProperty jsonProperty = properties.SingleOrDefault(prop => prop.Name == attribute.PropertyName);
                    if (jsonProperty != null)
                    {
                        objectProperty.SetValue(instance, jsonProperty.Value.ToString(), new object[] {});                        
                    }
                }
            }
           
            return instance;
            // {
            //    _Key = "A45",
            //    _FirstName = "John",
            //    _LastName = "Doe"
            // }
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
    [JsonConverter(typeof(CustomUserSerializer))]
    public class User
    {
        [JsonProperty(PropertyName = "key")]
        [JsonSerializeProperty(PropertyName = "_Key")]
        public string Key { get; set; }
        
        [JsonProperty("field1")]
        [JsonSerializeProperty(PropertyName = "_FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("field2")]
        [JsonSerializeProperty(PropertyName = "_LastName")]
        public string LastName { get; set; }
    }
