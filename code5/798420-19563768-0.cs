    public partial class Advert
    {
        [Key]
        public int ID { get; set; }
    
        [Required]
        public byte[] ImageData { get; set; }
    
        [Required]
        public string UrlToUse { get; set; }
    
        [Required]
        public string Author { get; set; }
    
        [Required]
        public int SchemaType { get; set; }
    
        public string Title { get; set; }
    }
