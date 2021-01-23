    foreach (var catalog in this.Catalogs)
    {
        catalog.Initialize();
        var needSpinner = catalog as IHaveASpinner;
        if (needSpinner != null)
        {
            needSpinner.Spinner = SpinnerViewModel.Instance;
        }
    }
