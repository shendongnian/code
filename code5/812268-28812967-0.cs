       var superset= repository.Products
          .Where(p => this.CurrentCategory == null 
                 || p.Category == this.CurrentCategory)
          .OrderBy(p => p.ProductID)
          .ToPagedList(page, PageSize);
    
       var subset = superset
          .AsEnumerable()
          .Select(p => new ProductViewModel
          {
              OtherData = p.UntranslateableMethod()  
          })
    
        var model = new StaticPagedList<ProductViewModel>(subset,
           superset.GetMetaData());
    }
