    [Table("SP_reslutclass")]
    public  class SP_reslutclass
    {
        [Key]
        public int emicount { get; set; }
        public DateTime Emidate { get; set; }
        public int ? Emistatus { get; set; }
        public int emiamount { get; set; }
    }
