    public void DisplayOfferings(Product[] products)
    {
        for (int i = 1; i <= products.length; i++ ) 
        {
          Console.WriteLine(i + ". " + products[i - 1].GetDetails() + "\n\n"); 
        }      
    }
