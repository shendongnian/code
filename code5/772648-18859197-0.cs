    [HttpPost]
    public ActionResult Update(AccountModel newInfo)
    {
        validateUserInfo(newInfo);
        if (ModelState.IsValid)
        {
            newInfo.updateToDatabase();
        }
        ModelState.Clear();
        return View(newInfo);
    }
