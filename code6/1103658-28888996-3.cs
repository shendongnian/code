    public ActionResult DoAction(ViewModel viewModel)
        {
            var response = _customerService.DoSomething(new DoActionRequest { Param1 = param1 });
            return HandleResponse(response, "Success");
        }
