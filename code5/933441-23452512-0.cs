    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool subscription { get; set; }
    
        public List<Article> Articles { get; set; }
        public Customer()
        {
            this.Articles = new List<Article>();
        }
    }
