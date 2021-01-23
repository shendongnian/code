    public string JsonString<T>(T obj)
    {
        DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(T));
    
        string jsonValue = string.Empty;
    
        using (MemoryStream memStrm = new MemoryStream())
        {
            jsonSer.WriteObject(memStrm, obj);
    
            byte[] jsonArray = memStrm.ToArray();
    
            jsonValue = System.Text.Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
        }
    
        return jsonValue;
    }
