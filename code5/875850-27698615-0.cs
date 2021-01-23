    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>()
               .HasMany(Proposal=> proposal.Responses)
               .WithRequired(response => response.Proposal)
               .HasForeignKey(response => response.ProposalId)
               .WillCascadeOnDelete(true);
        }
    }
