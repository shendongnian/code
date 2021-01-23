       MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
       DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<RootObject>));
       RootObject itemDataList = dataContractJsonSerializer.ReadObject(memoryStream) as RootObject;
       ChannelName  = itemDataList.listings.First().ChannelName ;
     
