    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NonEditable]
        public string SecurityId { get; set; }
    }
