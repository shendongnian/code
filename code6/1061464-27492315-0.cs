    [DataContract]
    public class SaveWidgetsDAL
    {
        [DataMember(Name="items")]
        public List<Widgets> wdata { get; set; }
        public SaveWidgetsDAL() { }
        [DataContract]
        public class Widgets
        {
            // I was able to figure out which JSON properties to which to map these properties.
            [DataMember(Name = "column")]
            public string ColumnId { get; set; }
            [DataMember(Name = "collapsed")]
            public string Collapsed { get; set; }
            // However it is unclear how to map these to your JSON.  
            [DataMember(Name = "sortno")]
            public string SortNo { get; set; }
            [DataMember(Name = "title")]
            public string Title { get; set; }
            [DataMember(Name = "userid")]
            public string UserId { get; set; }
            [DataMember(Name = "widgetid")]
            public string WidgetId { get; set; }
        }
    }
