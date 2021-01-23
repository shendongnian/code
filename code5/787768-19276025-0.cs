    modelBuilder.Entity<Leaves>().HasRequired(l => l.Applicant)
                                .WithMany(bp => bp.LeavesToApply)
                                .HasForeignKey(l => l.ApplicantId)
                                .WillCascadeOnDelete(false);
    modelBuilder.Entity<Leaves>().HasOptional(t => t.Approver)
                                 .WithMany(bp => bp.LeavesToApprove)
                                 .HasForeignKey(u => u.ApproverId)
                                 .WillCascadeOnDelete(false);
