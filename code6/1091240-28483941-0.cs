    set
    {
        if (myControlViewModels != null)
        {
            myControlViewModels.CollectionChanged -= OnControlViewModelsChanged;
        }
        this.myControlViewModels = value;
        this.NotifyPropertyChanged(m => m.IsMyControlVisible);
        if (myControlViewModels != null)
        {
            myControlViewModels.CollectionChanged += OnControlViewModelsChanged;
        }
    }
