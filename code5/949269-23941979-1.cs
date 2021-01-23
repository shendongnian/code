     public IEnumerable<SelectListItem> GetCategoryList(int selectedCatId)
     {     
       // Assuming that GetCategoriesFromDB is returning IEnumerable of Category 
        return GetCategoriesFromDB() 
                           .Select(cat => 
                               SelectListItem
                               {
                                   Text = cat.CategoryName + "/" + cat.CategoryName_En,
                                   Value = cat.ID,
                                   Selected = selectedCatId == cat.ID  
                               }).ToList();
     }
