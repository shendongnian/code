    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        
        ...
        _bindingSource = new BindingSource();
        _bindingSource.DataSource = _allItems;
        
        // my hidden label       // All my items have an Id property
        _labelHiddenId.DataBindings.Add("Text", BindingSource, "Id");
        _dataRepeaterList.DataSource = _bindingSource;
        _allItems.CollectionChanged += AllItems_CollectionChanged;
    }
