        public T GetDeserializedObject<T>(string jsonString) where T: class
    	{
    		var serializer = new DataContractJsonSerializer(typeof(T));
    		
    		using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
    		{
    			return serializer.ReadObject(stream) as T;
    		}
    	}
