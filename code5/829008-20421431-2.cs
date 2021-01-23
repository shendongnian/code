     public class CustomItem 
     {
    
        private string sProduct;
        public string Product
        {
          get { return sProduct; }
          set { sProduct = value; }
        }
    
        // i used int instead of string here
        private int nQuantity;
        public int Quantity
        {
          get { return nQuantity; }
          set { nQuantity = value; }
        }
        // i used double instead of string here    
        private double dPrice;
        public double Price
        {
          get { return dPrice; }
          set { dPrice = value; }
        }
        
        // simple constructor
        public CustomItem(string sProduct, int nQuantity, double dPrice)
        {
          this.Product = sProduct;
          this.Quantity = nQuantity;
          this.Price = dPrice;
        }
    
        // the listbox will use this method to show the item
        public override string ToString()
        {
          return sProduct + " " + nQuantity.ToString() + " " + dPrice.ToString() ;
        }
      }
