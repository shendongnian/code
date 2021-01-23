    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Rank { get; set; }
    }
