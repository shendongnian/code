          @using SosyalGundem.WebUI.DatabaseContext;
    public ActionResult SomeAction()
            {
                var model = new CategoriesModel
                {
                    NotDeletedCategories = db.PostCategories.Include("Posts").Where(x => !x.IsDeleted).ToList(),
                    DeletedCategories = db.PostCategories.Include("Posts").Where(x => x.IsDeleted).ToList()
                };
    
                return View(model);
    
    
            }
