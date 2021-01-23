    public class DataSource
    {
        public int Id { get; set; }
        //...
    }
    public class DataType
    {
        public int Id { get; set; }
        //...
    }
    public class DataBinding
    {
        [Key,ForeignKey("Source"),Column(Order = 0)]
        public int DataSourceId {get;set;}
        [Key,ForeignKey("Type"),Column(Order = 1)]
        public int DataTypeId {get;set;}
       public DataSource Source { get; set; }
       public DataType Type { get; set; }
       //...
    }
