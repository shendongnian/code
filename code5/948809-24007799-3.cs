    public class MenuItem : BaseModel
    {    
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        // I didn't have this exposed before //
        public int? UseSiblingClaim_Id { get; set; }
        public virtual MenuItem UseSiblingClaim { get; set; }
    }
