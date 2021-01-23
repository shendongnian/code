    public class DinnerViewModel
    {
        public DinnerViewModel()
        {
            Meal = new Meal();
            Beverage = new Beverage();
            Desert = new Desert();
        }
    
        public Meal Meal { get; set; }
        public Beverage Beverage { get; set; }
        public Desert Desert { get; set; }
    
        public decimal SalesTax { get; set; }
        public bool SeniorDiscount { get; set; }
    }
