    namespace WCF.HTTP.Unity3d
    {
    
    
        [ServiceContract]
        public interface IWCFContract
        {
            [OperationContract]
            [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
                      RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                       UriTemplate = "crossdomain.xml",
                       Method = "GET")]
            Stream crossdomain();
    
            [OperationContract]
            [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       UriTemplate = "/dac/room={room}",//&index={index}
                       Method = "GET")]
            Stream GetRoom(String room);
