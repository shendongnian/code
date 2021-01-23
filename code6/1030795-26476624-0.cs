    public class DogBowl
    {
        [Required]
        public int DogId { get; set; }
        [Required]
        public int BowlId { get; set; }
    }
    public class DogBowlInfo
    {
        public int DogId { get; set; }
        public int BowlId { get; set; }
        public string DogName { get; set; }
        public string BowlColor { get; set; }
    }
