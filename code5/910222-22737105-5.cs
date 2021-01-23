    private void NameOfYourAction_Mediator(object args)
    {
        MyViewModel viewModel = args as MyViewModel;
        if (viewModel != null)
            viewModel.PropertyA = someValue;
    }
    // Somewhere, may be in constructor of class
    Mediator.Register("NameOfYourAction", NameOfYourAction_Mediator);
