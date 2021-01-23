    public ActionResult View(int id)
    {
        var result = _repository.Find(id);
        if(result == null)
            return HttpNotFound(); //HttpNotFoundResult, which inherits from HttpStatusCodeResult
        return View(result); //ViewResult
    }
