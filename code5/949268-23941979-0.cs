     // Assuming that GetCategoriesFromDB is returning IEnumerable of Category 
     var categoriesList = GetCategoriesFromDB() 
                         .Select(cat => 
                               SelectListItem
                               {
                                   Text = cat.CategoryName + "/" + cat.CategoryName_En,
                                   Value = cat.ID  
                               }).ToList();
