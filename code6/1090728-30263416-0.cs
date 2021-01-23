    [Table("X", Schema = "MYSCHEMA")]
    public class Y
    {
        [Column("X_ID"), Key]
        public int Y_ID { get; set; }
        public virtual List<X> X { get; set; }
    }
    [Table("Y", Schema = "MYSCHEMA")]
    public class X
    {
        [Column("Y_ID"), Key]
        public int X_ID { get; set; }
        [Column("X_ID"), Key]
        public int Y_ID { get; set; }
        [ForeignKey("X_ID")]
        public virtual Y Y { get; set; }
    }
