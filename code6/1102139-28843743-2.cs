    public class CampingSpot
    {
        [Key]
        [Required(ErrorMessage = "Please select at least one CampingSpotID")]
        public int CampingSpotId { get; set; }
        public string SpotName { get; set; }  
    
        public virtual int ReservationId { get; set; }
    }
