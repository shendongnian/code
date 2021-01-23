    private Entities db = new Entities(); 
    public ActionResult GetItemCategories(GridParams g, string title)
                {
                    title = (title ?? "").ToLower();
                    Expression<Func<tbl_Category, bool>> ff = i => i.Name.ToLower().Contains(title);
                    
        
                    var rs = db.tbl_Category.AsExpandable().Where(ff).OrderBy(o => o.Name);
                    return Json(new GridModelBuilder<Models.tbl_Category>(rs, g) { }.Build());
                }
