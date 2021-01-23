    public abstract class CustomDictionaryTypeReaderBase : JsonConverter
    {
        protected abstract Type CreateDictionaryType(Type tKey, Type tValue);
        bool GetIDictionaryGenericParameters(Type objectType, out Type tKey, out Type tValue)
        {
            tKey = tValue = null;
            if (!objectType.IsGenericType)
                return false;
            var genericType = objectType.GetGenericTypeDefinition();
            if (genericType != typeof(IDictionary<,>))
                return false;
            var args = objectType.GetGenericArguments();
            if (args.Length != 2)
                tKey = tValue = null;
            tKey = args[0];
            tValue = args[1];
            return true;
        }
        
        public override bool CanConvert(Type objectType)
        {
            Type tKey, tValue;
            return GetIDictionaryGenericParameters(objectType, out tKey, out tValue);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue != null)
            {
                serializer.Populate(reader, existingValue);
                return existingValue;
            }
            else
            {
                Type tKey, tValue;
                bool ok = GetIDictionaryGenericParameters(objectType, out tKey, out tValue);
                if (!ok)
                {
                    return serializer.Deserialize(reader, objectType);
                }
                else
                {
                    var realType = CreateDictionaryType(tKey, tValue);
                    Debug.Assert(objectType.IsAssignableFrom(realType));
                    return serializer.Deserialize(reader, realType);
                }
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class MyCustomDictionaryTypeReader : CustomDictionaryTypeReaderBase
    {
        protected override Type CreateDictionaryType(Type tKey, Type tValue)
        {
            var dictType = typeof(MyDictionary<,>).MakeGenericType(new[] { tKey, tValue });
            return dictType;
        }
    }
