    public class ModerationResult
    {
       public int ModerationResultId { get; set; }
       public int ManualModerationReasonId { get; set; }
       
       [ForeignKey("ManualModerationReasonId ")]
       public ManualModerationReason ManualModerationReason { get; set; }
    }
    public class ManualModerationReason
    {
           public int ManualModerationReasonId { get; set; }
           public string Reason { get; set; }
           public List<ModerationResult> ModerationResults { get; set; }
     
    }
    modelBuilder.Entity<ManualModerationReason>()
                .HasMany(mreason => mreason.ModerationResults)
                .WithOptional(mresult => mresult.ManualModerationReason)
                .HasForeignKey(mresult => mresult.ManualModerationReasonId);
