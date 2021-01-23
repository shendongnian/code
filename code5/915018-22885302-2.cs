    class ProductModelDto
    {
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
    class ProductDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IEnumerable<ProductReviewDto> ProductReviews { get; set; }
    }
    class ProductReviewDto
    {
        public string ReviewerName { get; set; }
        public string Email { get; set; }
    }
