    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        using(var uow = _unitOfWorkManager.Begin())
        {
            try
            {
                Item item = _repoItems.Get(id.Value);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }
            finally
            {
               uow.Complete()
            };
        }
    }
