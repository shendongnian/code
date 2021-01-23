        public class DiscussionWall
        {
            [Required]
            public string CreatedBy { get; set; }
            [JsonIgnore]
            [ForeignKey("CreatedBy")]
            public Teacher Teacher { get; set; }
            public List<DiscussionTimeframe> Timeframes { get; set; }
        }
