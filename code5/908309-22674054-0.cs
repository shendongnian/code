    public class Survey
    {
        [XmlArray("links")]
        [XmlArrayItem("edit")]
        public string[] edit 
        {
            get 
            {
                return new [] {EditLink};
            } 
            set 
            {
                EditLink = value[0];
            }
        }
        
        [XmlIgnore]
        public string EditLink { get; set; }
    }
