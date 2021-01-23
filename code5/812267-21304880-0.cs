    public ViewResult List(int page =1, string category =null)
    {
        if (category != null) this.CurrentCategory = category;
        var products = repository.Products
                       .Where(p => this.CurrentCategory == null || p.Category == this.CurrentCategory)
                       .OrderBy(p => p.ProductID)
                       .Skip((page -1) * PageSize)
                       .Take(PageSize);
	var count = repository.Products
                       .Where(p => this.CurrentCategory == null || p.Category == this.CurrentCategory).Count();
	var resultAsPagedList = new StaticPagedList<Product>(products, page, PageSize, count);
        return View(resultAsPagedList);
    }
