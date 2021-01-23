    [HttpPost]
            [Authorize(Roles = "Admin, AdminStage")]
    		public ActionResult UpsertCategory([DataSourceRequest]DataSourceRequest request, YeagerTechWcfService.Category cat, Boolean blnInsert)
            {
                if (TryUpdateModel(cat))
                {
                    try
                    {
                        if (blnInsert)
    						db.AddCategory(cat);
                        else
                            db.EditCategory(cat);
    
                        return Json(new[] { cat }.ToDataSourceResult(request, ModelState));
                    }
