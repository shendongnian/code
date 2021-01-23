    [XmlRoot("createShepherdRequest", Namespace = "http://www.sheeps.pl/webapi/1_0")]
    public class CreateShepherdRequest
    {
        [XmlElement("shepherd")]
        public Shepherd Shepherd { get; set; }
    }
