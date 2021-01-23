    public class Reference
    {
        [Column(TypeName = "varchar")]
        public string DocumentID { get; set; }
        [Column(TypeName = "varchar")]
        public string DetailID { get; set; }
        [Column(TypeName = "varchar")]
        public string TransactionSet { get; set; }
        [Column(TypeName = "varchar")]
        public string Qualifier { get; set; }
        [Column(TypeName = "varchar")]
        public string ReferenceID { get; set; }
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
        public int ID { get; set; }
    }
