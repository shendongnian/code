      public void Update(Product product) {
            if (context.Entry(product).Property(u => u.Code).IsModified && context.Entry(product).Property(u => u.Name).IsModified) {
                product.Version += 1;
            }
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        }
