    [Table("TestGrandChild", Schema = "dbo")]
    public class TestGrandChild {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int TestGrandChildId { get; set; }
        [Key, ForeignKey("TestChild"), Column(Order = 2)]
        public int TestId { get; set; }
        [Key, ForeignKey("TestChild"), Column(Order = 3)]
        public int TestParentId { get; set; }
        public virtual TestChild TestChild { get; set; }
    }
