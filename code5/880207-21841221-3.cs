    public ActionResult Show(int modelId) {
        var model = context.Model.SingleOrDefault(m => m.ModelId == modelId);
        var viewModel = new MyViewModel();
        viewModel.uid = model.Id;
        viewModel.uname = model.UserName;
        return View(viewModel);
    }
    [HttpPost]
    public string Show(MyViewModel viewModel)
    {
        return viewMode.uname + viewModel.uid.ToString();
    }
