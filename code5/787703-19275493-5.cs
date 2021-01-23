    [HttpPost]
    public ActionResult Action(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Use your file here
            using (MemoryStream memoryStream = new MemoryStream())
            {
                model.File.InputStream.CopyTo(memoryStream);
            }
        }
    
        //Return some html back to calling page...
        return PartialView("YourPartialView");
    }
