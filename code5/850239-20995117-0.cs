    using (var reader = new StreamReader(e.Result))
     {
       string jsonString = reader.ReadToEnd();
       MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString));
       DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<RootObject>));
       List<RootObject> itemDataList = dataContractJsonSerializer.ReadObject(memoryStream) as List<RootObject>;
       ChannelName  = itemDataList.First().listings.First().ChannelName ;
     }
