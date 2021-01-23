    class VendorViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Website { get; set; }
        [Regex("regex for email")]
        public string Email { get; set; }
        [MaxLength(160)]
        public string Address { get; set; }
    }
