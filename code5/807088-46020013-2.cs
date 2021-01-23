    public class VehicleFeature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        [Key]
        public int VehicleId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        [Key]
        public int FeatureId{get;set;}
        public Vehicle Vehicle{get;set;}
        public Feature Feature{get;set;}
    }
