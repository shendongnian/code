    public ActionResult Calculate(String textBox)
    {
        Expression e = new Expression(textBox);
        MyViewModel model = new MyViewModel {
            Answer = e.Evaluate()
        };
        return View(model);
    }
