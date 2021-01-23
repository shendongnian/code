    [Serializable]
    public class User
    {
        [XmlElement("login")]
        [Key]
        public string login { get; set; }
        
        [XmlElement("KDP")]
        public int KDP { get; set; }
        [XmlElement("attended")]
        public int attended { get; set; }
       etc.
