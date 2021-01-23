    var product = context.Products.First();
    var photo = new ProductPhoto { ProductId = product.ProductId }; // Stub
    context.Entry(photo).State = System.Data.Entity.EntityState.Deleted;
    context.Products.Remove(product);
    context.SaveChanges();
