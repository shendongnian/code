    public List<ProductCategoryView> GetProductList()
    {
        var popupList = (from p in this.Products
                         join c in this.Categories 
                         on p.CategoryID equals c.CategoryID
                         select new JoinView
                         {
                             ProductID = p.ProductID,
                             ProductName= p. ProductName,
                             CategoryID = c.CategoryID,
                             CategoryName = c.CategoryName,
                             DateCreated = p.DateCreated,
                             IsActive = p.IsActive
                         }).OrderBy(p => p.CategoryName)
                           .ToList();
        return popupList;
    }
