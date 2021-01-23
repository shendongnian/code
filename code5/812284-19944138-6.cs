        [XmlRoot("Merchant")]
        public class Merchant
        {
            [XmlArray("Cuisines"), XmlArrayItem("Cuisine")]
        	public List<String> WebCuisine { get; set; }
        }
