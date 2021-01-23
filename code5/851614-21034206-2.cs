    [HttpPost]
    [ActionName("Index")]
    public ActionResult Index_Post(TestModel model)
    {
        for (int i = 0; i < model.Items.Count; i++)
        {
            if (string.IsNullOrEmpty(model.Items[i]))
            {
                // empty name is Items[i]
                ModelState.AddModelError(string.Format("Items[{0}]", i), "Required");
                return View(model);
            }
        }
        return null;
    }
