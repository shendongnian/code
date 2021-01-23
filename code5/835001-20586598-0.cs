    class MatchConfiguration : EntityTypeConfiguration<Match> {
        public MatchConfiguration() {
            this.HasRequired(m => m.TeamB)
                .WithMany(t => t.Matches) // if you don't have the property Team.Matches, you can pass no arguments here
                .HasForeignKey(t => t.TeamBId)
                .WillCascadeOnDelete(false);
        }
    }
    // in OnModelCreating in your db context:
    builder.Configurations.Add(new MatchConfiguration);
