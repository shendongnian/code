        class CollectionWithNamedElementsConverter : JsonConverter
        {
            static Type GetEnumerableType(Type type)
            {
                foreach (Type intType in type.GetInterfaces())
                {
                    if (intType.IsGenericType
                        && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        return intType.GetGenericArguments()[0];
                    }
                }
                return null;
            }
            public override bool CanConvert(Type objectType)
            {
                return typeof(IEnumerable).IsAssignableFrom(objectType)
                    && !typeof(string).IsAssignableFrom(objectType)
                    && GetEnumerableType(objectType) != null;
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JArray originalArray = JArray.Load(reader);
                if (originalArray == null)
                    return null;
                JArray array = new JArray();
                foreach (var item in originalArray)
                {
                    var child = item.Children<JProperty>().FirstOrDefault();
                    if (child != null)
                    {
                        var value = child.Value;
                        array.Add(child.Value);
                    }
                }
                return serializer.Deserialize(new StringReader(array.ToString()), objectType);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var objectType = value.GetType();
                var itemType = GetEnumerableType(objectType);
                IEnumerable collection = value as IEnumerable;
                writer.WriteStartArray();
                foreach (object item in collection)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(itemType.Name);
                    serializer.Serialize(writer, item);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
        }
