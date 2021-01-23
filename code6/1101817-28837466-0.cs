    [Route("/hello/{Name}","GET")]
    [DataContract]
    public class Greeting : IReturn<GreetingResponse>
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class GreetingResponse
    {
        [DataMember]
        public string Result { get; set; }
    }
