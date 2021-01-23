    public partial class UserPain
    {
        // ...
        
        [Column("Defects_Id")]
        public int DefectId { get; set; }
        
        [ForeignKey("DefectId")]
        public virtual Defect Defect { get; set; }
    }
