    public class PizzaTopping
    {
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public bool IsDoubleTopping { get; set; }
    
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Topping> Toppings { get; set; }
    }
    public class Pizza
    {
        public int PizzaId { get; set; }
    }
    
    public class Topping
    {
        public int ToppingId { get; set; }
    }
