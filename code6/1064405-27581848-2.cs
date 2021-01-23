    [HttpGet]
    public JsonResult GetSubCategories(string categoryID )
    {        
        int id = 0;
        if (Request.IsAjaxRequest() && int.TryParse(categoryID,out id))
        {
            using(WebStoreEntities1 db1 = new WebStoreEntities1())
            {
                var allSubCategory = db1.CategoryToSubCategories.Where(a => a.CategoryId.Equals(id)).OrderBy(a => a.SubCategory.SubCategoryName).ToList();
                
                return new JsonResult
                {
                    Data=allSubCategory,
                    JsonRequestBehavior=JsonRequestBehavior.AllowGet
                };                
            }
        }
        return new JsonResult
        {
            Data="error",
            JsonRequestBehavior=JsonRequestBehavior.AllowGet
        };        
    }
