    public class MeterWalkOrder
    {
        public MeterWalkOrder()
        {
            Meters = new List<IMeter>();
        }
        public String Name { get; set; }
        [XmlIgnore]
        public List<IMeter> Meters { get; set; }
        [XmlArrayItem(ElementName = "Meter")]
        [XmlArray(ElementName = "Meters")]
        public List<Meter> SerializableMeters
        {
            get
            {
                return Meters.Cast<Meter>().ToList();
            }
            set
            {
                Meters = new List<IMeter>(value);                
            }
        }
    }
	 public interface IMeter {
	   int MeterID { get; set; }
	 }
	 public class Meter : IMeter {
		 public int MeterID { get; set; }
		 public string SerialNumber { get; set; }
	 }
