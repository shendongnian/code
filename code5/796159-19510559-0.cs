    var query = list.Where(...);
    
    if(OrderByColumn=="BookCategoryName")
    {
       query = query.OrderBy(x=>x.a.BookCategoryName);
    }
    ....
