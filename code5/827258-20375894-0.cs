    public class Erand
    {
        public long ID { get; set; }
        public string AsjaNumber { get; set; }
    }
    public class ErandTsiv : Erand
    {
        [XmlElement("ID_KIS")]
        public long idKis { get; set; }
        [XmlElement("ID_ET")]
        public long idEt { get; set; }
    }
    [XmlRoot("ArrayOfErand")]
    public class ErandTsivList 
    {
        public ErandTsivList()
        {
            Erands = new List<ErandTsiv>();
        }
        [XmlElement("Erand")]
        public List<ErandTsiv> Erands { get; set; }
    }
