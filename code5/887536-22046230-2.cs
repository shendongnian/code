    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public int BuildingId { get; set; }        
    }
