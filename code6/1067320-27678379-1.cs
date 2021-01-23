    public ActionResult AddQuestion()
    {
        CheckBoxViewModel m = new CheckBoxViewModel();
        m.CheckBoxLists = new List<CheckBoxList>();
        m.CheckBoxLists.Add(new CheckBoxList() { CheckBoxDescription = "Hi1", CheckBoxId = 1, CheckBoxState = true});
        m.CheckBoxLists.Add(new CheckBoxList() { CheckBoxDescription = "Hi2", CheckBoxId = 2, CheckBoxState = true });
        m.CheckBoxLists.Add(new CheckBoxList() { CheckBoxDescription = "Hi3", CheckBoxId = 3, CheckBoxState = true });
        return View(m);
    }
