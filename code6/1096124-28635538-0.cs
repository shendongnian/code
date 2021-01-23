    [HttpPost]
    public ActionResult SomeForm(modelType model, FormCollection fc)
    {
        if(isValid())
            doSomething();
        else
            return SomeForm(model) // Line in Question
    }
