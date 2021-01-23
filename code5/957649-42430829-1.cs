    // setup model builder (wherever you setup your OData EDM)
    var messageAction = builder.EntityType<MessageDto>().Collection.Action("SendMessage");
    messageAction.Namespace = "YourNamespace";
    messageAction.Parameter<SendMessageRequest>("request");
    messageAction.Returns<SendMessageResponse>();
    // setup controller action (in controller, duh)
    [HttpPost]
    [ODataRoute("Messages/YourNamespace.SendMessage")]
    public IHttpActionResult SendMessage(ODataActionParameters parameters)
    {
    
        // parameter will be in the parameters argument
        //...your code
    
    }
    // SendMessageRequest
    public class SendMessageRequest
    {
        public Guid FromUserUid { get; set; }
        public Guid ToUserUid { get; set; }
        public string Message { get; set; }
    }
    // json request
    {
      "request": {
        "fromUserUid@odata.type": "#Guid",
        "fromUserUid": "9A49B9D6-037C-4929-9FB7-0FC627DC9EBD",
        "message": "test message",
        "toUserUid@odata.type": "#Guid",
        "toUserUid": "6BE85BFD-0D3F-487B-9F83-1037D4C35432"
      }
    }
 
