    Task _initializeTask;
    private void InitializeForm(List<NonDependencyObject> myCollection)
    {
        Action<NonDependencyObject> doWork = (nonDepObj) =>
            {
                var dependencyObject = CreateDependencyObject(nonDepObj);
                UiComponent.Add(dependencyObject);
                // Set up some binding on each dependencyObject and update progress bar
                ...
            };
        Func<Task> background = async () =>
            {
                foreach (var nonDependencyObject in myCollection)
                {
                    if (nonDependencyObject.NeedsToBeAdded())
                    {
                        doWork(nonDependencyObject);
                        await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
                    }
                }
            };
        _initializeTask = background();
    }
