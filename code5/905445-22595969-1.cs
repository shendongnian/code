    public ActionResult Test()
    {
        var model = new List<Models.TestViewModel>();
        model.Add(new TestViewModel() { Title = Title.Miss });
        model.Add(new TestViewModel() { Title = Title.Mrs });
        model.Add(new TestViewModel() { Title = null });
            
        return View(model);
    }
