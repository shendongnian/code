    List<Product> lp = new List<Product>();
    foreach (var line in Order.Lines) {
        Product p = lp.Where(x => x.Id == line.Product.Id).FirstOrDefault();
        if ( p == null ) {
            lp.Add(p);
        } else {
           line.Product = p;
        }
    }
    
