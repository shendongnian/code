    public class ContactViewModel
    {
        [DataType(DataType.MultilineText)]//<-- Add this line to work
        public string Message { get; set; }
    }
