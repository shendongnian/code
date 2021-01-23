    public class Restaurant
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public virtual List<RestaurantReviews> Reviews{ get; set; } 
    }
    
    public class RestaurantReviews
    {
        public int Id{ get; set;}
        public string Review { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; } 
    }
