       public class Region
      {
        public int RegionId { get; set; }
        public string RegionCode { get; set; }
        public string ApiUrl { get; set; }
        public ICollection<Universe> Universes { get; set; }
       }
