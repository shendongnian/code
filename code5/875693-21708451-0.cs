        public class DbConversation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ConversationId { get; set; }
        [ForeignKey("UserStartedId")]
        public virtual DbUserLight UserStarted { get; set; }
        public int UserStartedId { get; set; }
        [ForeignKey("UserRecipientId")]
        public virtual DbUserLight UserRecipient { get; set; }
        public int UserRecipientId { get; set; }
    
        public virtual IList<DbStoryMessage> Messages { get; set; }
    }
