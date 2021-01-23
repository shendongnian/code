    {
        Product product=new Product();
        try
        {
            using (CoffeeDBEntities db = new CoffeeDBEntities())
            {
                product = db.Products.Find(id);
            }
        }
        catch(Exception)
        {
            return null;
        }
        return product;
    }
