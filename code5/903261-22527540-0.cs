    private static void Main()
        {
            JsonMediaTypeFormatter mediaTypeFormatter = new JsonMediaTypeFormatter();
            mediaTypeFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                IgnoreSerializableAttribute = true
            };
            String cargo = "Hello";
            SerializableType serializableTypeOriginal = new SerializableType(cargo);
            String jsonFromSerializableType = JsonConvert.SerializeObject(serializableTypeOriginal);
            NonSerializableType nonSerializableTypeOriginalNonSerializableType = new NonSerializableType(cargo);
            String jsonFromNonSerializableType = JsonConvert.SerializeObject(nonSerializableTypeOriginalNonSerializableType);
            System.Diagnostics.Debug.Assert(jsonFromSerializableType == jsonFromNonSerializableType);
            HttpContent httpContent = new StringContent(jsonFromSerializableType, new UTF8Encoding(), "application/json");
            SerializableType serializableTypeFromSerializableType = httpContent.ReadAsAsync<SerializableType>(new[] { mediaTypeFormatter }).Result;
            //serializableTypeFromSerializableType.A == "Hello" ✔
            httpContent = new StringContent(jsonFromSerializableType, new UTF8Encoding(), "application/json");
            NonSerializableType nonSerializableTypeFromSerializableType = httpContent.ReadAsAsync<NonSerializableType>(new[] { mediaTypeFormatter }).Result;
            //nonSerializableTypeFromSerializableType.A == "Hello" ✔
            httpContent = new StringContent(jsonFromNonSerializableType, new UTF8Encoding(), "application/json");
            SerializableType serializableTypeFromNonSerializableType = httpContent.ReadAsAsync<SerializableType>(new[] { mediaTypeFormatter }).Result;
            //serializableTypeFromNonSerializableType.A == "Hello" ✔
            httpContent = new StringContent(jsonFromNonSerializableType, new UTF8Encoding(), "application/json");
            NonSerializableType nonSerializableTypeFromNonSerializableType = httpContent.ReadAsAsync<NonSerializableType>(new[] { mediaTypeFormatter }).Result;
            //nonSerializableTypeFromNonSerializableType.A == "Hello" ✔
           
        }
