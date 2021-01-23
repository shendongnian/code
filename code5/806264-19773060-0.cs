    private string deserializeJSON(string resp, bool code = false)
    {
        string value = string.Empty;
        ResponseClass deserialized = null;
        using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(resp)))
        {
            stream.Position = 0;
            var ser = new DataContractJsonSerializer(typeof(ResponseClassContainer));
            deserialized = (ser.ReadObject(stream) as ResponseClassContainer).d;
        }
        value = code ? deserialized.Response : deserialized.ResponseCode.ToString();
        return value;
    }
    [DataContract]
    public class ResponseClassContainer
    {
        [DataMember]
        public ResponseClass d { get; set; }
    }
    [DataContract]
    public class ResponseClass
    {
        [DataMember(Name="RespCode")]
        public int ResponseCode
        { get; set;}
        [DataMember(Name="RespMess")]
        public string ResponseMessage
        { get; set;}
        [DataMember(Name="Resp")]
        public string Response
        { get; set;}
    }
