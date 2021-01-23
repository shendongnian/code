    class WorkRelationship
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Myself")]
        public int MyselfId { get; set; }
        public virtual Person Myself { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Colleague")]
        public int ColleagueId { get; set; }
        public virtual Person Colleague { get; set; }
    }
