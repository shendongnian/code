    public Class DialNumber
    {
        public string Number{get;set;}
        public Conference Conference{get;set;}
    }
    modelBuilder
       .Entity<DialNumber>()
       .HasRequired(p => p.Conference);
       .WithMany(b => b.DialNumber)
       .HasForeignKey(p => p.ConferenceId);
