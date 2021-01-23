    public class Amount
        {
            public int Quantity { get; set; }
            public ThingsPrices ItemType { get; set; }        
        }    
    
        public static List<Amount> InputItems = new List<Amount>();
    
        public class AmmountCalculator
        {       
            public double GetTotalAmmount()
            {
                return InputItems.Sum(i => i.ItemType.Price*i.Quantity);
            }
        }
