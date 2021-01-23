    public ViewResult Create()
    {
        CreateChemicalViewModel viewModel = new CreateChemicalViewModel();
        viewModel.Sites = siteRepository.Sites;
        return View(viewModel);
    }
