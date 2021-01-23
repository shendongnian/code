    [Table("StuffDataModel")]
    public class StuffDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public byte[] Stuff { get; set; }
    }
