    public class Banner
    {
        [Key]
        public int Id { get; set; }
        public int IdForResult { get; set; }
        [ForeignKey("IdForResult")]
        public BannerResult Result { get; set; }
    }
    
    public class BannerResult
    {
        [Key]
        public int Id { get; set; }
        public int IdForBanner { get; set; }
        [ForeignKey("IdForBanner")]
        public Banner Banner { get; set; }
    }
