    public class ModelViewModel
    {
        public int Id { get; set; }
        [Required]
        public int RelationshipId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string ModelAttribute { get;set; }
    }
