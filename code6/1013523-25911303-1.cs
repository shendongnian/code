    public IQueryable GetProductList()
    {
        var popupList = from p in this.Products
                         join c in this.Categories 
                         on p.CategoryID equals c.CategoryID
                         select new
                         {
                             ProductID = p.ProductID,
                             ProductName= p. ProductName,
                             CategoryID = c.CategoryID,
                             CategoryName = c.CategoryName,
                             DateCreated = p.DateCreated,
                             IsActive = p.IsActive
                         };
        return popupList.OrderBy(p => p.CategoryName);
    }
