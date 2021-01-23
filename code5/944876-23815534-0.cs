    private class Person
    {
        [Required]
        public string FirstName { get; set; }
    
        [Required]
        public string LastName { get; set; }
    
        public bool Married { get; set; }
    
        [RequiredIfTrue("Married")]
        public string MaidenName { get; set; }
    }
