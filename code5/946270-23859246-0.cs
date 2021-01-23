    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            this.HasMany(x => x.Recipients)
                .WithMany(x => x.MessagesReceived)
                .Map(x => 
                     x.ToTable("MessageRecipients")
                      .MapLeftKey("MessageId")
                      .MapRightKey("UserId"));
        }
    }
