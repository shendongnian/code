    [DataContract]
    public class SaveWidgetsDAL
    {
        [DataMember(Name = "items")]
        public List<Widgets> wdata { get; set; }
        public SaveWidgetsDAL() { }
        [DataContract]
        public class Widgets
        {
            // I was able to figure out which JSON properties to which to map these properties.
            [DataMember(Name = "id")]
            public string Id { get; set; }
            [DataMember(Name = "collapsed")]
            public string Collapsed { get; set; }
            [DataMember(Name = "order")]
            public string Order { get; set; }
            [DataMember(Name = "column")]
            public string ColumnId { get; set; }
        }
    }
