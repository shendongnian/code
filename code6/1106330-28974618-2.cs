    public class TableA
    {
        [Key]
        public Guid Id { get; set; }
        public virtual TableB TableB { get; set; }
        public virtual TableC TableC { get; set; }
    }
    public class TableB
    {
        [Key]
        [ForeignKey("TableA")]
        public Guid Id { get; set; }
        public virtual TableA TableA { get; set; }
        public virtual TableC TableC { get; set; }
    }
    public class TableC
    {
        [Key]
        [ForeignKey("TableB")]
        public Guid Id { get; set; }
        public virtual TableB TableB { get; set; }
        
        [Required]
        public virtual TableA TableA { get; set; }
    }
