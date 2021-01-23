            if (ModelState.IsValid)
            {
                if (flag == "dropdown")
                {
                    //your code goes here.
                }
                if (flag == "button")
                {
                    //your code goes here/
                }
            }
            var mdoel = db.GetProductCategories.where(id=>id.ProductCategoryID==ProductCatID).ToList();
            return Json(Model, JsonRequestBehavior.AllowGet);
        }
