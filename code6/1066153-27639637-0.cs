    public interface MyDataStructure
    {
        public int id { get; set; }
        public DateTime d_time { get; set; }
    }
    [DataContract]
    class Mapper1:MyDataStructure
    {
        [DataMember(Name="DataID")]
        public int id { get; set; }
        [DataMember(Name = "Time")]
        public DateTime d_time { get; set; }
    }
    class Mapper2:MyDataStructure
    {
        [DataMember(Name = "ID")]
        public int id { get; set; }
        [DataMember(Name = "DATE")]
        public DateTime d_time { get; set; }
    }
