    public class Recipient
    {
        .....
        [Key]
        public int Id { get; set; } // If this is your PK
    
        public virtual ICollection<Message> Messages { get; set; } // navigational Property to Messages
    }
