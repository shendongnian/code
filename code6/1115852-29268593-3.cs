    public class Message
    {
        .....
        [Key]
        public int Id { get; set; } // If this is your PK
        public int RecipientId { get; set; } // This would be FK
        public virtual Recipient Recipient { get; set; } // navigational property back to Recipient
    }
