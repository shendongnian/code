    public class Products
    {
       public Products()
       {
           product_items = new List<dynamic>();
       }
       public List<dynamic> product_items { get; set; }
    }
    products.product_items.Add(new { _at = 1, product_id = "999" });
