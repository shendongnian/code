    [MessageContract]
    public class ExampleResponse
    {
       private string _myResponse = String.Empty;
       [MessageBodyMember(Name = "ResponseToGive", Namespace = "http://myserver:8888")]
       public string ResponseToGive
       {
         get { return _myResponse; }
         set { _myResponse = value; }
       }
    }
