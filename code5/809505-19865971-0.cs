    public IEnumerable<Products> GetProduct(MyDbContext db){
       //query created before-hand
       var nike = db.Products.Where(p => p.Brand == "Nike").OrderBy(p => p.Name);
       return nike;
    }
    
    //and then in your method:
    using (var db = new MyDbContext()){
       var nike = GetProduct(db); //MyDbContext object attached here.
       foreach(var product in nike){
         Debug.WriteLine(product.Name);
       }
    }
