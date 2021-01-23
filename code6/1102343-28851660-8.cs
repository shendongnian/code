    public ActionResult View(IEnumerable<YourModel> model)
    {
      // Save your collection and redirect
    }
    [HttpPost]
    public JsonResult Delete(int ID)
    {
      // Delete the product in the database based on the ID
      return Json(true);
    }
