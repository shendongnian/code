    public class YogaSpaceImage
    {
        public int YogaSpaceImageId { get; set; }        
        public byte[] Image { get; set; }
        public byte[] ImageThumbnail { get; set; }
        public string ContentType { get; set; }
        public int Ordering { get; set; }
        public int YogaSpaceId { get; set; }
        [Required] <-- This will delete the image, if removed from parent
        public virtual YogaSpace YogaSpace { get; set; }
    }
