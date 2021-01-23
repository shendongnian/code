    public class Reference
    {
        [Column(TypeName = "varchar"), MaxLength(100)]
        public string DocumentID { get; set; }
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string DetailID { get; set; }
        [Column(TypeName = "char"), MaxLength(5)]
        public string TransactionSet { get; set; }
        [Column(TypeName = "varchar"), MaxLength(80)]
        public string Qualifier { get; set; }
        [MaxLength(30)]
        public string ReferenceID { get; set; }
        [MaxLength(80)]
        public string Description { get; set; }
        public int ID { get; set; }
    }
