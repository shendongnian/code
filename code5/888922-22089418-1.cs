    public class Publication
    {
        [DataMember(Name="dc:creator")]
        public string Creator { set; get; }
        [DataMember(Name="element:publicationName")]
        public string PublicationName { set; get; }
        [DataMember(Name="element:issn")]
        public string Issn { set; get; }
    }
