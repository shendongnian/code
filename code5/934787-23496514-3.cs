    public class SendEmailModel
    {
        [Required]
        public IEnumerable<Recipient> Recipients { get; set; }
        ...
    }
