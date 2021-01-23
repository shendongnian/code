    public class Picture
    {
        public int Id { get; set; }
 
        // Don't need these 4 any more.
        // public string PictureFrontUrl { get; set; }
        // public string PictureBackUrl { get; set; }
        // public string PictureRightSideUrl { get; set; }
        // public string PictureLeftSideUrl { get; set; }
        public string PictureUrl { get; set; }
        public string PictureNote { get; set; }
        public string PictureUploadBy { get; set; }
        public DateTime? PictureUploadDate { get; set; }
        public DateTime? PictureDate { get; set; }
        public string ClientName { get; set; }
        public string PictureType { get; set; }
        public Guid MeasurementId { get; set; }
        [ForeignKey("MeasurementId")]
        public virtual Measurement Measurement { get; set; }
    }
