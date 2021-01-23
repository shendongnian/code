    public class Companion
    {
        public int CompanionId { get; set; }
    
        public int? LinkedCompanionId { get; set; }
    
        [ForeignKey("LinkedCompanionId")]
        // ParentCompanion
        public virtual Companion LinkedCompanion { get; set; }
    
        [InverseProperty("LinkedCompanion")]
        // ChildrenCompanions
        public virtual ICollection<Companion> CompanionLinkedCompanions { get; set; }
    }
