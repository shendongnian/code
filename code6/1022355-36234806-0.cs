    List<SubCategory> lstSubCategory = GetSubCateroy() // list from repo
    
     var subCategoryToReturn = lstSubCategory.Select(S => new { Id  = S.Id, Name = S.Name }); 
    
    return this.Json(subCategoryToReturn , JsonRequestBehavior.AllowGet);
