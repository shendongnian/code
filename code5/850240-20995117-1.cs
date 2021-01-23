       MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
       DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<RootObject>));
       List<RootObject> itemDataList = dataContractJsonSerializer.ReadObject(memoryStream) as List<RootObject>;
       ChannelName  = itemDataList.First().listings.First().ChannelName ;
     
