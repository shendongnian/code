    public class DinerViewModel
    {
        public Meal Meal { get; set; }
        public Beverage Beverage { get; set; }
        public Desert Desert { get; set; }
        public decimal SalesTax { get; set; }
        public bool SeniorDiscount { get; set; }
        public decimal TotalCostOfDinner
        {
            get
            {
                decimal subtotal = 0M;
                if(Meal != null) subtotal += Meal.Cost;
                if(Beverage != null) subtotal += Beverage.Cost;
                if(Desert != null) subtotal += Desert.Cost;
                if (SeniorDiscount) subtotal -= subtotal * 0.1M;
                return subtotal + (subtotal * SalesTax);
            }
        }
    }
