    public ActionResult Tags(string id) 
    {   
          Tag tag = GetTag(id);
           return View("Index", tag.Posts);
    }
