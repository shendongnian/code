    public void DisplayOfferings(List<Product> products)
    { 
        int i = 1;
        foreach(var product in products)
        { 
            Console.WriteLine(i + ". " + product.GetDetails() + "\n\n"); 
            i++;
        }
    }
