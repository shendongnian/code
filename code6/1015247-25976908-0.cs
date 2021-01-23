    public class ContactMessage
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public bool Delivered { get; set; }
        public ContactMessage()
        {
            this.Delivered = false;
        }
    }
