    public ActionResult AddFragment()
    {
        var viewModel = new FragmentViewModel(parameters);
        return PartialView("Fragment", viewModel);
    }
