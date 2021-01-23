    [HttpPost]
    public ActionResult LocalFileHandlerAction(DataTableModel DataTableModel)
    {
       // Validate model
       if(ModelState.IsValid)
       {
          // Save logic
       }
    
        return View(DataTableModel);
    
    }
