        public class Host
        {
             [XmlElement("hostId")]
             public string hostId { get; set; }              
    
             [XmlArray("images")] // CHANGED
             [XmlArrayItem("image", typeof(Image))] // CHANGED
             public List<Image> Listeimages { get; set; }
        }
