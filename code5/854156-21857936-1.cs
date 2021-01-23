    public class TableA
    {
        public TableA()
        {
            ListBs = new List<TableB>();
        }
        [Key]
        public int Id { get; set; }
        public int TableB_Id { get; set; }
        [InverseProperty("TableA_Mains")]
        [ForeignKey("TableB_Id")]
        public TableB MainB { get; set; }
        [InverseProperty("refA")]
        public virtual ICollection<TableB> ListBs { get; set; }
    }
    public class TableB
    {
        [Key]
        public int Id { get; set; }
        public int TableA_Id { get; set; }
        [Foreignkey("TableA_Id")]
        [InverseProperty("ListBs")]
        public virtual TableA refA { get; set; }
        [Required]
        public string Text { get; set; }
        [InverseProperty("MainB")]
        public virtual ICollection<TableA> TableA_Mains { get; set; }
    }
