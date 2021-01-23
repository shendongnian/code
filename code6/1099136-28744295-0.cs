    Model.Entries.AssociationChanged += ModelEntries_PropertyChanged;
    protected void ModelEntries_PropertyChanged(object sender, CollectionChangedEventArgs)
    {
        RaisePropertyChanged(() => this.HasEntries);
    }
