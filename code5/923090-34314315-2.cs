    ViewModelCategory vmc = new ViewModelCategory
                {
                    Category = category,
                    Categories = _businessCategories.GetItems().Where(x => x.ParentID == null).Select(x => new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.ID.ToString()
                    }).ToList(),
                    
                    ChildCategories = _businessCategories.GetItems().Where(x=>x.ParentID != null).Select(x => new SelectListItem
                    {
                        Text = _businessCategories.GetItems().Where(a => a.ID == x.ParentID).FirstOrDefault().CategoryName + " > " + x.CategoryName,
                        Value = x.ID.ToString()
                    }).ToList(),
                };
