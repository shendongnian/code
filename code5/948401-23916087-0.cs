    class Movie {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Title is required.")]
        [Remote("UniqueTitle", "Validation")]
        public String Title { get; set; }
        [Required(ErrorMessage="Price is required.")]
        public float Price { get; set; }
    }
