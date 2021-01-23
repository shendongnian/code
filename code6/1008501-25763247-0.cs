    public class ImageCollection
    {
        [XmlElement("image")]  
        public List<Image> Listeimages { get; set; }
    }
    public class Host
    {
         [XmlElement("hostId")]
         public string hostId { get; set; }              
         [XmlElement("images")]
         public ImageCollection ImageCollection { get; set; }
    }
