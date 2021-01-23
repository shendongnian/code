    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class entry
    {
        [XmlAttribute("itemNum", Namespace = "http://www.live.com/marketplace")]
        public int itemNum { get; set; }
        public string title { get; set; }
        public string totalItems { get; set; }
        public string reducedDescription { get; set; }
        public string ratingId { get; set; }
        public string developer { get; set; }
        public string publisher { get; set; }
        public string tittleId { get; set; }
        public string ratingAggregate { get; set; }
        public string numberOfRatings { get; set; }
        public string boxImage { get; set; }
        public string categories { get; set; }
    }
