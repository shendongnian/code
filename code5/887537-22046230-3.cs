    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        [ForeignKey("ContainingBuilding")]
        public int BuildingId { get; set; }      
        public virtual Building ContainingBuilding{ get; set;}
    }
