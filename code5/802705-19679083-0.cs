        //deserialize json array
        using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
        {
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(PiwikDbData[]));
            visitlist = serializer.ReadObject(stream) as PiwikDbData[];
        }
        Response.Write(visitlist.Length);
