    public class StreamList
    {
        [DataMember]
        public List<Stream> Stream;
    }
    [OperationContract]
    [WebInvoke(UriTemplate = "SEPTAB", Method = "POST")]
    StreamList AddSEPTAB(List<SEPTABLINE> separationTabLines);
