    public ActionResult Index(string LoanAgent)
    {
        var viewModel = new PipelineViewModel
        {
            PipeNewLeads = ....
            PipeDispLeads = ....
         };
        return View(viewModel);
    }
