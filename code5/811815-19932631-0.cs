        public SweepstakesConfiguration()
        {
            Property(c => c.Id).HasColumnName("SweepstakesId");
            HasOptional(c => c.WinningApplicant)
                .WithMany()
                .HasForeignKey(c => c.WinnerId);
        }
        public SweepstakesApplicantConfiguration()
        {
            Property(a => a.Id).HasColumnName("SweepstakesApplicantId");
            HasRequired(a => a.Sweepstakes)
                .WithMany(s => s.Applicants)
                .HasForeignKey(a => a.SweepstakesId)
                .WillCascadeOnDelete();
            HasRequired(a => a.Buyer)
                .WithMany(b => b.SweepstakesApplications)
                .HasForeignKey(a => a.BuyerId);
            HasRequired(a => a.Agent)
                .WithMany()
                .HasForeignKey(a => a.AgentId);
        }
