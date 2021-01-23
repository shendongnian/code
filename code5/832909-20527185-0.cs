        var products = new List<Product>();
        
        using (SqlDataReader reader = cmd.ExecuteReader()) ????
        {
             Product p = new Product();
             p.Name = reader.Field<string>("Name");
             p.Sku =  reader.Field<string>("Sku");  
             // etc.
             products.Add(p);
        }
