    class Client
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Birthdate { get; set; }
        public string Observations { get; set; }
    }
    class Person : Client
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
    class Company : Client
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Company { get; set; }
        
    }
