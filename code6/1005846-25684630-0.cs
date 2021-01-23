    public class MessageRecipient
	{
		public int MessageId { get; set; }
        public int UserId { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
	}
