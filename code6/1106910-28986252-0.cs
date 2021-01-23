    var prod = db.Products.Where(x => x.Id == model.Id).Single();
                {
                    prod.Id = model.Id;
                    ...
                    prod.CategoryID = model.CategoryList.Select(m => m.CatId)
                    //but Select returned the List of CatId, I suggest thet prod.CategoryID is List               
                }
    db.SaveChanges();
