    Task.Factory
        .StartNew<IList<District>>(GetAllDistricts)
        .ContinueWith(districts =>
        {
            // UI thread
        }, TaskScheduler.FromCurrentSynchronizationContext());
