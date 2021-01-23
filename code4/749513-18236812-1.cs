    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Chat> InitiatedChats { get; set; }
        public virtual ICollection<Chat> ParticipantInChats { get; set; }
    }
    public class Chat
    {
        [Key, Column(Order = 0)]
        public int User1Id { get; set; }
        public virtual User User1 { get; set; }
        [Key, Column(Order = 1)]
        public int User2Id { get; set; }
        public virtual User User2 { get; set; }
        public string Channel { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>()
            .HasRequired(s => s.User1)
            .WithMany(u => u.InitiatedChats)
            .HasForeignKey(s => s.User1Id)
            .WillCascadeOnDelete(false);
        modelBuilder.Entity<Chat>()
            .HasRequired(s => s.User2)
            .WithMany(u => u.ParticipantInChats)
            .HasForeignKey(s => s.User2Id)
            .WillCascadeOnDelete(false);
        base.OnModelCreating(modelBuilder);
    }
