    public abstract class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductCatagoryId { get; set; }
    
        public abstract void Save();
    }
    public class DryFruits : Product
    {
        public decimal WeightInGrams { get; set; }
        public decimal RatePerGram { get; set; }
        public override void Save()
        {
            //save the product
        }
    }
