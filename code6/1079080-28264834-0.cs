    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ID,UsersLanguage,OtherLanguage,Notes")] Word word, int idOfCollection)
    {
        if (ModelState.IsValid)
        {
            var dbWord = db.Words.Find(word.ID);
            dbWord.UsersLanguage = word.UsersLanguage;
            dbWord.OtherLanguage = word.OtherLanguage;
            dbWord.Notes = word.Notes;
    
            db.SaveChanges(); // in this case dbWord is saved so datetime fields remains intact
            return RedirectToAction("Index", new { idOfCollection = idOfCollection });
        }
        return View(word);
    }
