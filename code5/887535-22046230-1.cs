    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }      
        public virtual Building Building { get; set;}
    }
