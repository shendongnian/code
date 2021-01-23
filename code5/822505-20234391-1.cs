    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
        // Verify that the user selected a file
        if (file != null && file.ContentLength > 0) 
        {
            // extract only the fielname
            var fileName = Path.GetFileName(file.FileName);
    
            // then save on the server...
            var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
            file.SaveAs(path);
        }
        // redirect back to the index action to show the form once again
        return RedirectToAction("Index");        
    }
