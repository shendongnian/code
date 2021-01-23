    public class Orderline
    {
        [Key]
        public int OrderlineId {get; set;}
    
        [ForeignKey("PizzaId")]
        public Pizza PizzaId {get; set;}
        public decimal OrderlinePrice {get; set;}
    }
