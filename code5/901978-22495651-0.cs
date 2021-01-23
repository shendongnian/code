     public class CompanionLinkedCompanion
    {
     public int CompanionId { get; set; }
     [ForeignKey("CompanionId")]
     [InverseProperty("CompanionLinkedCompanions")]
     public virtual Companion Companion { get; set; }
     public int LinkedCompanionId { get; set; }
     [ForeignKey("LinkedCompanionId")]
     [InverseProperty("LinkedCompanions")]
     public virtual Companion LinkedCompanion { get; set; }
    }
    public class Companion
    {
      [InverseProperty("Companion")]
      public virtual ICollection<CompanionLinkedCompanion> CompanionLinkedCompanions { get; set; }
      [InverseProperty("LinkedCompanion")]
      public virtual ICollection<CompanionLinkedCompanion> LinkedCompanions { get; set; }
    }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
           modelBuilder.Entity<CompanionLinkedCompanion>().HasRequired(x => x.Companion).WithMany().HasForeignKey(x => x.CompanionId).willCascadeOnDelete(false);
          modelBuilder.Entity<CompanionLinkedCompanion>().HasRequired(x => x.LinkedCompanion).WithMany().HasForeignKey(x => x.LinkedCompanionId);
      }
