    public ActionResult PostComment()
    {
        var vModel = new CreateViewModel();
        vModel.Comments = comrepository.GetAllComments().ToList();
        return View(vModel); 
    }
