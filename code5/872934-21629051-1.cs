    public ActionResult Tags(string id) 
    {   
         Tag tag = GetTag(id);
         //TODO define pageNumber and pageSize or pass them as parameters to your action method
         return View("Index",tag.Posts.ToPagedList(pageNumber, pageSize));
    }
