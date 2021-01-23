        [DataContract]
        public class Video
        {
            [Key]
            [DataMember(IsRequired = false)]
            public int VideoId { get; set; }
            [DataMember(IsRequired = false)]
            public int UserId { get; set; } // user that created the video, unrelated
            public int? UpvoterId { get; set; }
            [Required]
            [DataMember]
            public virtual IList<Tag> Tags { get; set; }
        }
