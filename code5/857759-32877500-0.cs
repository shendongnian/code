       using System.Runtime.Serialization.Json;
       public static T GetObjectFromJson<T>(string jsonString, Type type)
        {
            var dcSerializer = new DataContractJsonSerializer(type);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)dcSerializer.ReadObject(stream);
            }
        }
