    public class Restaurant{
        public Restaurant()
        {
            Types=new List<RestaurantType>();
        }
        [Key]
        public int Id{get; set;}
        [Required]
        public string Name{get; set;}
    
        public virtual ICollection<RestaurantType> Types{get;set;}
    }
    
    public class RestaurantType{
       [Key]
       public int Id{get;set;}
       [Required]
       public string Type{get; set;}
       public int RestaurantId{get; set;}
       
       [ForeignKey("RestaurantId")]
       public Restaurant Restaurant{get;set;}    
    }
