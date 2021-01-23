    public class ObjectToPropertyDictionaryArraySurrogate<T> : IDataContractSurrogate
    {
        class ListDictionaryArray : List<Dictionary<string, string>>
        {
        }
        #region IDataContractSurrogate Members
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(T))
                return typeof(ListDictionaryArray);
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is ListDictionaryArray)
            {
                var array = (ListDictionaryArray)obj;
                var dict = array.SelectMany(pair => pair).ToDictionary(pair => pair.Key, pair => pair.Value);
                var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dict);
                return DataContractJsonSerializerHelper.GetObject<T>(json, new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            }
            return obj;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(T))
            {
                var json = DataContractJsonSerializerHelper.GetJson((T)obj, new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                var dict = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, string>>(json);
                var array = new ListDictionaryArray();
                array.AddRange(dict.Select(pair => new[] { pair }.ToDictionary(p => p.Key, p => p.Value)));
                return array;
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public static class DataContractJsonSerializerHelper
    {
        public static string GetJson<T>(T obj, DataContractJsonSerializer serializer)
        {
            using (var memory = new MemoryStream())
            {
                serializer.WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static string GetJson<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return GetJson(obj, serializer);
        }
        public static string GetJson<T>(T obj, DataContractJsonSerializerSettings settings)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType(), settings);
            return GetJson<T>(obj, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer)
        {
            using (var stream = GenerateStreamFromString(json))
            {
                var obj = serializer.ReadObject(stream);
                return (T)obj;
            }
        }
        public static T GetObject<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return GetObject<T>(json, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializerSettings settings)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), settings);
            return GetObject<T>(json, serializer);
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
    }
