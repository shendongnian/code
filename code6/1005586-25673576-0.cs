    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/RestService.Models")]
    public class ArrayDTO
    {
        [XmlElement("LaborDTO")]
        public LaborDTO[] collection { get; set; }
    }
