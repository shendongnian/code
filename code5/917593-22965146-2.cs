    public class Hospital
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TownId { get; set; }
    
        //you can uncomment this for less coding for searching, filtering etc..
        //public int CityId { get; set; }
        
        public bool IsAvailable { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Hospital()
        {
          this.IsAvailable = true;
        }
    }
