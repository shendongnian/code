    [HttpPost]
    Public ActionResult Edit(First first)
    {
      if(ModelState.Isvalid)
      {
        if(first.FirstID>0)
        {
          datacontext.Entry(first).State=EntityState.Modified;
          datacontext.Entry(first.Second).State=EntityState.Modified;
          datacontext.Entry(first.Second.Third).State=EntityState.Modified;
        }
        else
        {
          datacontext.First.Add(first);
        }
        datacontext.SaveChanges()
        Return RedirectToAction("Index");
      }
     Return View(first);
    }
