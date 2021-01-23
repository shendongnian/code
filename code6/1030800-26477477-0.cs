    public class ProductDetails
    {
         public string ProdName { get; set; }
         public string Price { get; set; }
    }    
    public class Customer
    {
         public string Name { get; set; }
         public List<ProductDetails> Products { get; set; }
    }
    
    List<Customer> Customers = new List<Customer>();
    
    private void btnRegister_Click(object sender, EventArgs e)
    {
        if(boxName.Text.Length != 0 && productsList.CheckedItems.Count != 0)
        {
            Customer customer = new Customer();
            customer.Name = boxName.Text;
            customer.Products = new List<ProductDetails>();
     
            //This is what I tried
            foreach(var item in productsList.CheckedItems)
            {
                ProductDetails details = new ProductDetails()
                details.ProdName = item,ToString();
                details.Price=  5;
                customer.Products.Add(details);
            }
            Customers.Add(customer);
            customersList.Items.Add(customer.Name);
        }
    }
