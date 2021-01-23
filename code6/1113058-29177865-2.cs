    public class YogaSpaceImage
    {
        public int YogaSpaceImageId { get; set; }        
        public byte[] Image { get; set; }
        public byte[] ImageThumbnail { get; set; }
        public string ContentType { get; set; }
        public int Ordering { get; set; }
        [Required]
        public int YogaSpaceId { get; set; }
        public virtual YogaSpace YogaSpace { get; set; }
    }
