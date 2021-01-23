    [HttpPost]
    public JsonResult TestAjax(AddModel model)
    {
        int iSum = model.number1 + model.number2;
        ResultViewModel viewModel = new ResultViewModel();
        viewModel.Sum = iSum;
        return Json(viewModel);
    }
