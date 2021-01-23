    public ActionResult SampleView()
    {
        var model = new Event();
        model.GetStudents(); //call GetStudent method so the DropDownStudent object will be populated.
        return View(model);
    }
