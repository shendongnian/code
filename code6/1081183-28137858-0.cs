    [ServiceContract]
    public class TestService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AddUser/{phoneNo}/{regId}")]
        public string AddUser(string phoneNo, String regId, Stream image)
        {
            var ss = new StreamReader(image).ReadToEnd();
            return phoneNo + " " + regId;
        }
    }
