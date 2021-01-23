    [DataContract]
    class Foo
    {
        [DataMember(Name = "ratings_total")]
        public Dictionary<int,int> RatingsTotal { get; set; }
    }
