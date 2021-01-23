    public List<Item> DeserializeJSON(string jsonString)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Item>)); 
        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)); 
        var obj = (List<Item>)ser.ReadObject(stream);
        return obj;
    }
