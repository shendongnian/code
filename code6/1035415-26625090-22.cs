    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(respJson)))
    {
        var serializer = new DataContractJsonSerializer(typeof(Model[]));
        var resp = serializer.ReadObject(ms) as Model[];
    
        var result = resp.FirstOrDefault(o => o.Name == "test3").CdnStreamingUri;
    }
