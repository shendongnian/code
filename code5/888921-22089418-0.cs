    public class Publication
    {
        [DataMember(Name="dc:creator")]
        public string creator { set; get; }
        [DataMember(Name="element:publicationName")]
        public string publicationName { set; get; }
        [DataMember(Name="element:issn")]
        public string issn { set; get; }
    }
