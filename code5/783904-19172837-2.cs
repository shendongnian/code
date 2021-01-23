    public class PizzaTopping
    {   
        public int PizzaToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
    
    public class Pizza
    { 
         public int PizzaId { get; set; } 
         public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
    
    public class Topping
    {   
         public int ToppingId { get; set; }
         public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
