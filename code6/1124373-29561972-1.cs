    public class ManualModerationReason
    {
           public int ManualModerationReasonId { get; set; }
           public string Reason { get; set; }
           public List<ModerationResult> ModerationResults { get; set; }
     
    }
    modelBuilder.Entity<ManualModerationReason>().HasMany( m => m.ModerationResults).WithOptional(mr => mr.ManualModerationReason);
