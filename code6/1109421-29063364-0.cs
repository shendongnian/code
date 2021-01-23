    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult Create([Bind(Include = "Information_Id,Information_Title,Information_LinkText,Information_URLBody")] Information information, int InformationContainer_Id)
    {
    	if (ModelState.IsValid)
    	{
    		information.InformationContainer_Id = InformationContainer_Id;
    		db.Informations.Add(information);
    		db.SaveChanges();
    		return RedirectToAction("Index");
    	}
    	return View(information);
    }
