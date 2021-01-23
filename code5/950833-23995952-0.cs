    [Table(Name = "tqStandort")]
    public class Standort
    {
        [Column(IsPrimaryKey = true, DbType = "Int IDENTITY NOT NULL", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int Id;
        
        ...
    }
