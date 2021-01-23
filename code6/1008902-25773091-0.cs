    public ActionResult Save(int activeId, string text)
    {
       var elementToEdit = _repository.Posts.ElementAt(activeid);
       return SaveEdit(activeId, text, elementToEdit);
    }
    public ActionResult Edit(int activeId, string text)
    {
       var elementToEdit = _repository.Editables.ElementAt(activeId);
       return SaveEdit(activeId, text, elementToEdit);
    }
    private ActionResult SaveEdit(int activeId, string text, object elementToEdit)
    {
       // logic from your original method
    }
