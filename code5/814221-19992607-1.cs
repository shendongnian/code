    public Move {
        public string MoveName {get;  set}
        [XmlElement("Tags")]
        public List<Tag> oTags = new List<Tag>;
    }
    
    public Tag {
        public string TagName {get; set;}
    }
