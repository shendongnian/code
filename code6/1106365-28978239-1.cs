    public ActionResult Edit()
    {
        Grid model = new Grid();
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(Grid model)
    {
        // Get the value of the 3rd column in the 5th row
        int value = model.Rows[2].Columns[4];
    }
