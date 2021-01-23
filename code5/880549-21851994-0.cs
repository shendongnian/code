    [ForeignKey("DeferredDataId")]
    public class MemberDataSet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public int? DeferredDataId { get; set; }
        [ForeignKey("Id")]
        public virtual DeferredData DeferredData { get; set; }
    }
