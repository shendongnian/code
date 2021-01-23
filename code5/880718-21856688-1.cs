    public class MemberDataSet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public virtual DeferredData DeferredData { get; set; }
    }
    
    public class DeferredData
    {
        // DeferredData.Id is both the PK and a FK to MemberDataSet
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        [ForeignKey( "MemberDataSet" )]
        public int Id { get; set; }
    
        [Required]
        public virtual MemberDataSet MemberDataSet { get; set; }
    }
