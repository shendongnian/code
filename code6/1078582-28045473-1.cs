    ...OnLaunched(...)
    {
    ...
            DispatcherHelper.Initialize();
            ViewModelLocator.SetAndReg();
            ServiceLocator.Current.GetInstance<MyViewModel>();
    ...
    }
