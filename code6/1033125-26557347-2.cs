    [AcceptVerbs(HttpVerbs.Get)]
    public JsonResult LoadProductsBySupplier(int parentId)
    {
      List<int> ctgyIds = _categoryService.GetAllCategoriesByParentCategoryId(parentId).Select(c => c.ID).ToList();
      var products= _productService.SearchProducts(categoryIds: ctgyIds, storeId: _storeContext.CurrentStore.Id, orderBy: ProductSortingEnum.NameAsc).AsEnumerable().Select(p => new
      {
        ID = p.ID,
        Text = p.Name.Substring(m.Name.IndexOf(' ') + 1)
      });
      return Json(products, JsonRequestBehavior.AllowGet);
    }
