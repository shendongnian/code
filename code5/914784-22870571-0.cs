        public static TElement Single<TElement>
          (this IQueryable<TElement> query)
    {
        if (query.Count() != 1)
        {
            throw new InvalidOperationException();
        }
        return query.First();
    }
    
     
    
    // Use it like this
    
    Product prod = (from p in db.Product
                    where p.ProductID == 711
                    select p).Single();
