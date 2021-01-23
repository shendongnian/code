    [Table("StuffDataModel")]
    public class StuffDataModel
    {
        [PrimaryKey]
        public int Id { set; get; }
        public byte[] Stuff { set; get; }
    }
