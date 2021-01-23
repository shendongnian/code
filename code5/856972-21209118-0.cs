    // In both cases, we want the command to be disabled when loading:
    LoadModels = new ReactiveCommand(this.WhenAny(x => x.LoadingModels, x => !x.Value));
    LoadModels.RegisterAsyncTask(_ => taskClient.GetModelsAsync())
        .Subscribe(items => 
        {
            // This Using makes it so the UI only looks at the collection
            // once we're totally done updating it, since we're basically
            // changing it completely.
            using (_models.SuppressChangeNotifications())
            {
                _models.Clear();
                _models.AddRange(items);
            }
        });
    LoadModels.ThrownExceptions
        .Subscribe(ex => Console.WriteLine("GetModelsAsync blew up: " + ex.ToString());
    // NB: _loadingModels is an ObservableAsPropertyHelper<bool>
    LoadModels.IsExecuting
        .ToProperty(this, x => x.LoadingModels, out _loadingModels);
